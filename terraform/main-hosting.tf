
  #####################
  # Storage Container #
  #####################

  resource "azurerm_storage_container" "tf_storage_container" {
  name                  = local.tfstate_container_name
  storage_account_name  = local.azurerm_terraform_storage_account
  container_access_type = "private"
}
