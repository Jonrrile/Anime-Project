using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anime.Models;
using Microsoft.Data.SqlClient;


namespace Anime.Repositories
{
    public interface ITitleRepository
    {
        List<Title> GetTitles();
        Title GetTitleById(int id);
    }
}
