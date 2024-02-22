
######################
# Storage Container #
#######################

variable "tfstate_storage_container_name" {
  type = string
  description = "Storage container to store the tfstate file"

}

variable "tf_state_storage_account"{
  type = string
  description = "Terraform TFstate storage account name"
}


#############
# General #
#############


variable "resource_group_name"{
  type = string
  description = "Resource Group name"
}

variable "project_name"{
  type = string
  description = "Project name"
}

variable "environment" {
  type = string
  description  = "Environment name "
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

###################
## Tenant config#
####################

/*
variable "client_id" {
  type = string
  description = "client id"
  default = "value"
}

variable "client_secret" {
  type = string
  description = "client secret"
  default = "value"
}

variable "tenantid"{
  type = string
  description = "Tenant id"
  default = "value"
}

variable "subscriptionid" {
  type = string
  description = "Subscription id "
  default = "value"
}
 */

############
# Identity #
############
variable "msi_id" {
  type        = string
  description = "The Managed Service Identity ID. If this value isn't null (the default), 'data.azurerm_client_config.current.object_id' will be set to this value."
  default     = null
}


/*
################
# Container App#
################

variable "container_app_image_name" {
  type = string
  description = "This variable is to define container App image name"
}

variable "az_container_port" {
  type = number
  description = "This variable defines the port of the Container App"
  default     = 8080
}


variable "az_app_kestrel_endpoint" {
  description = "Endpoint for Kestrel setup"
  type        = string
}


###################
# Github Registry #
###################

variable "registry_server" {
  description = "Container registry server"
  type        = string
}

variable "registry_username" {
  description = "Container registry username"
  type        = string
}

variable "registry_password" {
  description = "Container registry password"
  type        = string
}

variable "registry_custom_image_url" {
  description = "Pass in the address to your image from your custom registry"
  type        = string
}

variable "serviceprinciple_identity"{
  description = "Variable to define the service principle"
  type = string
}
*/