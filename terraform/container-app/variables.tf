###########
# General #
###########
variable "project_name" {
  description = "project name, used along with `environment` as a prefix for all resources"
  type        = string
}


variable "environment" {
  description = "Environment name, used along with `project_name` as a prefix for all resources"
  type        = string
}

variable "azure_location" {
  description = "Recourse location"
  type        = string
}

variable "az_tag_environment" {
  description = "Environment tag to be applied to all resources"
  type        = string
}

variable "az_tag_product" {
  description = "Product tag to be applied to all resources"
  type        = string
}

############
# Identity #
############
variable "msi_id" {
  type        = string
  description = "The Managed Service Identity ID. If this value isn't null (the default), 'data.azurerm_client_config.current.object_id' will be set to this value."
  default     = null
}


#######################
# Azure App Container #
#######################
variable "az_app_kestrel_endpoint" {
  description = "Endpoint for Kestrel setup"
  type        = string
}

variable "az_container_port" {
  description = "What port the container app is bound to"
  type        = number
  default     = 8080
}


variable "container_app_min_replicas" {
  description = "Minimum replicas for the container app"
  type        = number
  default     = 1
}

variable "container_app_max_replicas" {
  description = "Maximum replicas for the container app"
  type        = number
  default     = 2
}

variable "container_app_http_concurrency" {
  description = "Scale up at this number of HTTP requests"
  type        = number
  default     = 10
}

##################
# CDN/Front Door #
##################
variable "cdn_create_custom_domain" {
  description = "A flag to create the A and TXT records for the container app as part of setting up the cdn"
  type        = bool
  default     = false
}