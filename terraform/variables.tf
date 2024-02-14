
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

