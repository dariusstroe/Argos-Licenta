﻿namespace Argos.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CartItem>()
				.HasKey(ci => new { ci.UserId, ci.ProductId, ci.ProductTypeId });

			modelBuilder.Entity<ItemVariant>()
				.HasKey(p => new { p.ProductId, p.ProductTypeId });

			modelBuilder.Entity<OrderItem>()
				.HasKey(oi => new { oi.OrderId, oi.ProductId, oi.ProductTypeId });

			modelBuilder.Entity<ItemType>().HasData(
					new ItemType { Id = 1, Name = "Default" },
					new ItemType { Id = 2, Name = "Paperback" },
					new ItemType { Id = 3, Name = "E-Book" },
					new ItemType { Id = 4, Name = "Audiobook" },
					new ItemType { Id = 5, Name = "Stream" },
					new ItemType { Id = 6, Name = "Blu-ray" },
					new ItemType { Id = 7, Name = "VHS" },
					new ItemType { Id = 8, Name = "PC" },
					new ItemType { Id = 9, Name = "PlayStation" },
					new ItemType { Id = 10, Name = "Xbox" }
				);

			modelBuilder.Entity<ItemVariant>().HasData(
			   new ItemVariant
			   {
				   ProductId = 1,
				   ProductTypeId = 2,
				   Price = 9.99m,
				   OriginalPrice = 19.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 1,
				   ProductTypeId = 3,
				   Price = 7.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 1,
				   ProductTypeId = 4,
				   Price = 19.99m,
				   OriginalPrice = 29.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 2,
				   ProductTypeId = 2,
				   Price = 7.99m,
				   OriginalPrice = 14.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 3,
				   ProductTypeId = 2,
				   Price = 6.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 4,
				   ProductTypeId = 5,
				   Price = 3.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 4,
				   ProductTypeId = 6,
				   Price = 9.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 4,
				   ProductTypeId = 7,
				   Price = 19.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 5,
				   ProductTypeId = 5,
				   Price = 3.99m,
			   },
			   new ItemVariant
			   {
				   ProductId = 6,
				   ProductTypeId = 5,
				   Price = 2.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 7,
				   ProductTypeId = 8,
				   Price = 19.99m,
				   OriginalPrice = 29.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 7,
				   ProductTypeId = 9,
				   Price = 69.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 7,
				   ProductTypeId = 10,
				   Price = 49.99m,
				   OriginalPrice = 59.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 8,
				   ProductTypeId = 8,
				   Price = 9.99m,
				   OriginalPrice = 24.99m,
			   },
			   new ItemVariant
			   {
				   ProductId = 9,
				   ProductTypeId = 8,
				   Price = 14.99m
			   },
			   new ItemVariant
			   {
				   ProductId = 10,
				   ProductTypeId = 1,
				   Price = 159.99m,
				   OriginalPrice = 299m
			   },
			   new ItemVariant
			   {
				   ProductId = 11,
				   ProductTypeId = 1,
				   Price = 79.99m,
				   OriginalPrice = 399m
			   });

			modelBuilder.Entity<Category>().HasData(
					 new Category
					 {
						 Id = 1,
						 Name = "Books",
						 Url = "books"
					 },
					 new Category
					 {
						 Id = 2,
						 Name = "Movies",
						 Url = "movies"
					 },
					 new Category
					 {
						 Id = 3,
						 Name = "Video Games",
						 Url = "video-games"
					 }
				 );


			modelBuilder.Entity<Product>().HasData(
					new Product
					{
						Id = 1,
						Title = "Carte1",
						Description = "Descriere1",
						ImageUrl = "https://mcdn.elefant.ro/mnresize/350/350/is/product-images/cartero/120e608a/8874/4e34/8c0b/94ec3204b406/120e608a-8874-4e34-8c0b-94ec3204b406_1.jpg",
						//Price = 9.99m,
						CategoryId = 1,
						Featured = true
					},
					new Product
					{
						Id = 2,
						Title = "Carte2",
						Description = "Descriere2",
						ImageUrl = "https://mcdn.elefant.ro/mnresize/350/350/images/63/2010963/atomic-habits-o-cale-usoara-si-eficienta-de-a-ti-forma-obiceiuri-bune-si-a-scapa-de-cele-proaste_1_fullsize.jpg",
						//Price = 19.99m,
						CategoryId = 1,
						Featured = true
					},
					new Product
					{
						Id = 3,
						Title = "Carte3",
						Description = "Descriere3",
						ImageUrl = "https://mcdn.elefant.ro/mnresize/350/350/images/90/276490/ugly-love-despre-fata-urata-a-iubirii_1_fullsize.jpg",
						//Price = 29.99m,
						CategoryId = 1,
					},
					new Product
					{
						Id = 4,
						CategoryId = 2,
						Title = "The Matrix",
						Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c1/The_Matrix_Poster.jpg",
						Featured = true
					},
					new Product
					{
						Id = 5,
						CategoryId = 2,
						Title = "Back to the Future",
						Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d2/Back_to_the_Future.jpg",
					},
					new Product
					{
						Id = 6,
						CategoryId = 2,
						Title = "Toy Story",
						Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/1/13/Toy_Story.jpg",

					},
					new Product
					{
						Id = 7,
						CategoryId = 3,
						Title = "Half-Life 2",
						Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/2/25/Half-Life_2_cover.jpg",

					},
					new Product
					{
						Id = 8,
						CategoryId = 3,
						Title = "Diablo II",
						Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/d/d5/Diablo_II_Coverart.png",
					},
					new Product
					{
						Id = 9,
						CategoryId = 3,
						Title = "Day of the Tentacle",
						Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/en/7/79/Day_of_the_Tentacle_artwork.jpg",
						Featured = true
					},
					new Product
					{
						Id = 10,
						CategoryId = 3,
						Title = "Xbox",
						Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/4/43/Xbox-console.jpg",
					},
					new Product
					{
						Id = 11,
						CategoryId = 3,
						Title = "Super Nintendo Entertainment System",
						Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
						ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/e/ee/Nintendo-Super-Famicom-Set-FL.jpg",
					}
				);
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ItemType> ItemTypes { get; set; }
		public DbSet<ItemVariant> ItemVariants { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Image> Images { get; set; }

	}
}