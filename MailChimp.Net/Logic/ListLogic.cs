﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;

namespace MailChimp.Net.Logic
{
    internal class ListLogic : BaseLogic, IListLogic
    {
        public ListLogic(string apiKey): base(apiKey){}
        
        public async Task<IEnumerable<List>> GetAllAsync(ListRequest request = null)
        {
            try
            {
                using (var client = CreateMailClient("lists"))
                {
                    var response = await client.GetAsync(request?.ToQueryString());
                    response.EnsureSuccessStatusCode();

                    var listResponse = await response.Content.ReadAsAsync<ListResponse>();
                    return listResponse.Lists;
                }
            }
            catch (Exception ex)
            {
                
            }

            return null;
        }

        public async Task<List> GetAsync(string id)
        {
            try
            {
                using (var client = CreateMailClient("lists/"))
                {
                    var response = await client.GetAsync($"{id}");
                    response.EnsureSuccessStatusCode();
                    return await response.Content.ReadAsAsync<List>();
                }
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
