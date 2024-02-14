provider "azurerm" {
# subscription_id = var.subscriptionid
#  tenant_id = var.tenantid
#  client_id = var.client_id
#  client_secret = var.client_secret
  features {}
  skip_provider_registration = true
  storage_use_azuread        = true
}
