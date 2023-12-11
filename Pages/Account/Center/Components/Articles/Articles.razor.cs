using System.Collections.Generic;
using New_folder.Models;
using Microsoft.AspNetCore.Components;

namespace New_folder.Pages.Account.Center
{
    public partial class Articles
    {
        [Parameter] public IList<ListItemDataType> List { get; set; }
    }
}