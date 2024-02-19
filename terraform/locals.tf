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
  registry_server           = var.registry_server
  registry_username         = var.registry_username
  registry_password         = var.registry_password
  registry_custom_image_url = var.registry_custom_image_url


  tags = {
    "Environment"      = var.az_tag_environment,
    "Service Offering" = var.az_tag_product,
    "Product"          = var.az_tag_product
 }


    ########################
    ### Container App ###
    ########################

   container_app_image_name = var.container_app_image_name
   container_port           = var.az_container_port
   kestrel_endpoint = var.az_app_kestrel_endpoint

   ##################
   # Azure KeyVault #
   ##################
   kv_name = "${local.environment}${local.project_name}-kv"


   ###########
  # tfstate storage container #
   ###########
   tfstate_container_name = var.tfstate_storage_container_name
   azurerm_terraform_storage_account = var.tf_state_storage_account

  ####################
  # Managed Identity #
  ####################
  user_identity_name = var.serviceprinciple_identity
}
