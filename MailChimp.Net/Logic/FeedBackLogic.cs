﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

namespace MailChimp.Net.Logic
{
    internal class FeedBackLogic : BaseLogic, IFeedbackLogic
    {
        public FeedBackLogic(string apiKey) : base(apiKey)
        {
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync(string campaignId, FeedbackRequest request = null)
        {
            using (var client = CreateMailClient("campaigns/"))
            {
                var response = await client.GetAsync($"{campaignId}/feedback{request?.ToQueryString()}");
                response.EnsureSuccessStatusCode();

                var listResponse = await response.Content.ReadAsAsync<FeedBackResponse>();
                return listResponse.Feedback;
            }
        }

        public async Task<Feedback> GetAsync(string campaignId, string feedBackId)
        {
            using (var client = CreateMailClient("campaigns/"))
            {
                var response = await client.GetAsync($"{campaignId}/feedback/{feedBackId}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Feedback>();
            }
        }

        public async Task<Feedback> AddOrUpdateAsync(string campaignId, Feedback feedback)
        {
            using (var client = CreateMailClient("campaigns/"))
            {
                var response = await client.PostAsJsonAsync($"{campaignId}/feedback/{feedback?.FeedbackId}", feedback);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<Feedback>();
            }
        }
        public async Task DeleteAsync(string campaignId, string feedbackId)
        {
            using (var client = CreateMailClient("campaigns/"))
            {
                var response = await client.DeleteAsync($"{campaignId}/feedback/{feedbackId}");
                response.EnsureSuccessStatusCode();
            }
        }
    }
}