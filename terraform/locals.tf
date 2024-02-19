locals {

  ###########
  # General #
  ###########
  current_user_id           = coalesce(var.msi_id, data.azurerm_client_config.current.object_id)
  project_name              = var.project_name
  environment               = var.environment
  azure_location            = var.azure_location
  resource_prefix           = "${local.environment}${local.project_name}"
  azure_resource_group_name = var.resource_group_name


  tags = {
    "Environment"      = var.az_tag_environment,
    "Service Offering" = var.az_tag_product,
    "Product"          = var.az_tag_product
  }

  ##################
  # Azure KeyVault #
  ##################
  kv_name = "${local.environment}${local.project_name}-kv"


  ###########
  # tfstate storage container #
  ###########
  tfstate_container_name = var.tfstate_storage_container_name
  azurerm_terraform_storage_account = var.tf_state_storage_account
}
