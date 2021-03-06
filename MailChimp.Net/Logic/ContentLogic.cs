﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

namespace MailChimp.Net.Logic
{
    internal class ContentLogic : BaseLogic, IContentLogic
    {
        public ContentLogic(string apiKey): base(apiKey){}

        public async Task<Content> GetAsync(string campaignId)
        {
            try
            {
                using (var client = CreateMailClient("campaigns/"))
                {
                    var response = await client.GetAsync($"{campaignId}/contents");
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsAsync<Content>();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public async Task<Content> AddOrUpdateAsync(string campaignId, ContentRequest content)
        {
            try
            {
                using (var client = CreateMailClient("campaigns/"))
                {
                    var response = await client.PutAsJsonAsync($"{campaignId}/contents", content);
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsAsync<Content>();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }

    }
}
