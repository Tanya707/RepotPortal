﻿using System.Text.Json.Serialization;

namespace API.Business.Models.Responses.Items
{
    public class UserItem
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("userId")]
        public string UserId { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("fullName")]
        public string FullName { get; set; }

        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }

        [JsonPropertyName("userRole")]
        public string UserRole { get; set; }
    }
}