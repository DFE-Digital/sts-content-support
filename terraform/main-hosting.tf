  #####################
  # Key Vault #
  #####################

 resource "azurerm_key_vault" "vault" {
  name                       = local.kv_name
  location                   = local.azure_location
  resource_group_name        = local.azure_resource_group_name
  tenant_id                  = data.azurerm_client_config.current.tenant_id
  sku_name                   = "standard"
  soft_delete_retention_days = 90
  enable_rbac_authorization  = false
  tags                       = local.tags
  purge_protection_enabled   = true

  # network_acls {
  # bypass                     = "None"
  # default_action             = "Deny"
  #  virtual_network_subnet_ids = [module.main_hosting.networking.subnet_id]
  #}

  #lifecycle {
  #  ignore_changes = [network_acls[0].ip_rules]
  # }
 }

  resource "azurerm_key_vault_access_policy" "vault_access_policy_serviceprinciple" {
    key_vault_id = azurerm_key_vault.vault.id
    tenant_id    = data.azurerm_client_config.current.tenant_id
    object_id    = local.current_user_id   

    secret_permissions = ["List", "Get", "Set","Delete","Recover","Backup","Restore"]
    key_permissions    = ["List", "Get", "Create", "GetRotationPolicy", "SetRotationPolicy", "Delete", "Purge", "UnwrapKey", "WrapKey"]
  }

  resource "azurerm_key_vault_secret" "vault_secret_contentful_deliveryapikey" {  
    key_vault_id = azurerm_key_vault.vault.id
    name         = "S190d-github-deployment-client-secret"
    value        = "temp value"
 
    lifecycle {
      ignore_changes = [
        value,
        expiration_date
      ]
    }
  }



  #####################
  # Storage Container #
  #####################

 resource "azurerm_storage_container" "tf_storage_container" {
  name                  = local.tfstate_container_name
  storage_account_name  = local.azurerm_terraform_storage_account
  container_access_type = "private"
}



module "main_hosting" {
  source = "github.com/DFE-Digital/terraform-azurerm-container-apps-hosting?ref=v1.2.0"

  ###########
  # General #
  ###########
  environment    = local.environment
  project_name   = local.project_name
  azure_location = local.azure_location
  tags           = local.tags
  
  

  #################
  # Container App #
  #################
  enable_container_registry           = true
  use_external_container_registry_url = true
  image_name                          = local.container_app_image_name
  container_port                      = local.container_port
  container_secret_environment_variables = {
    "AZURE_CLIENT_ID" = azurerm_user_assigned_identity.user_assigned_identity.client_id,
    "KeyVaultName"    = local.kv_name
  }

  container_environment_variables = {
    "Kestrel__Endpoints__Http__Url"       = local.kestrel_endpoint,
    "ASPNETCORE_FORWARDEDHEADERS_ENABLED" = "true"
  }

  container_app_identities = {
    type         = "UserAssigned",
    identity_ids = [azurerm_user_assigned_identity.user_assigned_identity.id]
  }


  #############################
  # Github Container Registry #
  #############################
  registry_server           = local.registry_server
  registry_username         = local.registry_username
  registry_password         = local.registry_password
  registry_custom_image_url = local.registry_custom_image_url

}