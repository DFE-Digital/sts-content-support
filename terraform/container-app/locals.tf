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


  tags = {
    "Environment"      = var.az_tag_environment,
    "Service Offering" = var.az_tag_product,
    "Product"          = var.az_tag_product
  }

  #################
  # Container App #
  #################
  container_app_image_name       = "content-support-app"
  kestrel_endpoint               = var.az_app_kestrel_endpoint
  container_port                 = var.az_container_port
  container_app_min_replicas     = var.container_app_min_replicas
  container_app_max_replicas     = var.container_app_max_replicas
  container_app_http_concurrency = var.container_app_http_concurrency


  ####################
  # Managed Identity #
  ####################
  user_identity_name = "${local.resource_prefix}-mi"


  ##################
  # Azure KeyVault #
  ##################
  kv_name = "${local.environment}cands-kv"

  ##################
  # CDN/Front Door #
  ##################
  cdn_create_custom_domain = var.cdn_create_custom_domain


}
