resource "azurerm_key_vault" "vault" {
  name                       = local.kv_name
  location                   = local.azure_location
  resource_group_name        = module.main_hosting.azurerm_resource_group_default.name
  tenant_id                  = data.azurerm_client_config.current.tenant_id
  sku_name                   = "standard"
  soft_delete_retention_days = 90
  enable_rbac_authorization  = false
  tags                       = local.tags
  purge_protection_enabled   = false

  network_acls {
    bypass                     = "None"
    default_action             = "Deny"
    virtual_network_subnet_ids = [module.main_hosting.networking.subnet_id]
  }

  lifecycle {
    ignore_changes = [network_acls[0].ip_rules]
  }
}

resource "azurerm_key_vault_access_policy" "vault_access_policy_tf" {
  key_vault_id = azurerm_key_vault.vault.id
  tenant_id    = data.azurerm_client_config.current.tenant_id
  object_id    = local.current_user_id

  secret_permissions = ["List", "Get", "Set"]
  key_permissions    = ["List", "Get", "Create", "GetRotationPolicy", "SetRotationPolicy", "Delete", "Purge", "UnwrapKey", "WrapKey"]
}

resource "azurerm_key_vault_access_policy" "vault_access_policy_mi" {
  key_vault_id = azurerm_key_vault.vault.id
  tenant_id    = data.azurerm_client_config.current.tenant_id
  object_id    = azurerm_user_assigned_identity.user_assigned_identity.principal_id

  secret_permissions = ["List", "Get"]
  key_permissions    = ["List", "Get", "WrapKey", "UnwrapKey"]
}