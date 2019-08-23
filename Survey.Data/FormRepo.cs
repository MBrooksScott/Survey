using Dapper;
using Microsoft.Extensions.Configuration;
using Survey.Data.Interfaces;
using Survey.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Data
{
    public class FormRepository : IFormRepository
    {
        private string _connectionString;
        public FormRepository (IConfiguration config)
        {
            _connectionString = config.GetConnectionString("default");
        }

        public async Task<IEnumerable<OutlineItem>> GetOutlineItems(int? FormId = null)
        {
            IEnumerable<OutlineItem> items = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                items = await connection.QueryAsync<OutlineItem>("SELECT * FROM dbo.Outline");
            }
            var rootItems = new List<OutlineItem>();
            foreach (OutlineItem root in items.Where(i => i.ParentOutlineItemId == null))
            {
                root.Children = GetChildItems(root, items);
                rootItems.Add(root);
            }
            return rootItems;
        }

        private List<OutlineItem> GetChildItems(OutlineItem parentItem, IEnumerable<OutlineItem> allItems)
        {
            var parentId = parentItem.OutlineItemId;
            var children = allItems.Where(i => i.ParentOutlineItemId == parentId).ToList();
            
            for (int i = 0; i < children.Count(); i++)
            {
                var child = children[i];
                child.Children = GetChildItems(child, allItems);
            }

            return children;
        }
    }
}


