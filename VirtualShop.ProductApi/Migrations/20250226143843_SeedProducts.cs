﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VirtualShop.ProductApi.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                   "Values('Caderno', 7.55, 'Caderno', 10, 'caderno1.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                   "Values('Lápis', 3.45, 'Lápis preto', 20, 'lapis1.jpg', 1)");

            mb.Sql("Insert into Products(Name, Price, Description, Stock, ImageUrl, CategoryId)" +
                   "Values('Clips', 5.33, 'Clip para papel', 50, 'clips1.jpg', 2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Products");
        }
    }
}
