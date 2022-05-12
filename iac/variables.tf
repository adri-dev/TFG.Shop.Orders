
variable "cluster_name" {
  default = "tfgk8s"
}

variable "resource_group_name" {
  default = "tfg-k8s"
}

variable "sql_server_name" {
  default = "tfg-sql-svr"
}

variable "SQL_PASSWORD" {
  sensitive = true
}