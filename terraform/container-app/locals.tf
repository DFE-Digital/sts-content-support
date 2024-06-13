locals {
  ###########
  # General #
  ###########
  current_user_id     = coalesce(var.msi_id, data.azurerm_client_config.current.object_id)
  project_name        = var.project_name
  environment         = var.environment
  azure_location      = var.azure_location
  resource_prefix     = "${local.environment}${local.project_name}"
  resource_group_name = module.main_hosting.azurerm_resource_group_default.name
  registry_server     = var.registry_server
  registry_username   = var.registry_username
  registry_password   = var.registry_password


  tags = {
    "Environment"      = var.az_tag_environment,
    "Service Offering" = var.az_tag_product,
    "Product"          = var.az_tag_product
  }

  #################
  # Container App #
  #################
  container_app_image_name = "content-support-app"
  kestrel_endpoint         = var.az_app_kestrel_endpoint
  container_port           = var.az_container_port

  ####################
  # Managed Identity #
  ####################
  user_identity_name = "${local.resource_prefix}-mi"



  ##################
  # Azure KeyVault #
  ##################
  kv_name                   = "${local.environment}cands-kv"
  contentful_deliveryapikey = var.contentful_deliveryapikey
  contentful_previewapikey  = var.contentful_previewapikey
  contentful_spaceid        = var.contentful_spaceid
  contentful_environment    = var.contentful_environment
  ##################
  # CDN/Front Door #
  ##################
  cdn_create_custom_domain = var.cdn_create_custom_domain
}
