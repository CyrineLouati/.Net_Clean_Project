/*
 * 
 * public DbSet<Chirurgien> Chirurgiens { get; set; }
protected override void OnModelCreating(ModelBuilder modelBuilder)
{

    //using external config
    modelBuilder.ApplyConfiguration(new ProductConfiguration());

    //keys
    modelBuilder.Entity<Patient>().HasKey(c => c.CategoryId);
    modelBuilder.Entity<Patient>().HasKey(f => new { f.DateAchat, f.ClientFk, f.ProductFk });

    //Foreign Key
    modelBuilder.Entity<Operation>().HasOne(o => o.Patient).WithMany(p => p.Operations)
        .HasForeignKey(o => o.PatientId);

    //Instead of ANNOTATIONS
    modelBuilder.Property(c => c.Name).HasMaxLength(50).IsRequired();
    modelBuilder.Entity<Patient>().Property(p => p.CIN).HasMaxLength(8).IsFixedLength();
    modelBuilder.Entity<Operation>().Property(o => o.DateDebut).IsRequired();

    //Owns
    modelBuilder.Entity<Chemical>().OwnsOne(c => c.MyAddress, myadd =>
    {
        myadd.Property(a =>
        a.StreetAddress).HasColumnName("MyStreet").HasMaxLength(50);

        myadd.Property(a => a.City).HasColumnName("MyCity").IsRequired();
    });
    //if private access
    modelBuilder.Entity<Chemical>().OwnsOne(typeof(Address), "MyAddress");
******
*RELATIONS
******
    //ManyToMany
    modelBuilder.Entity<Operation>().HasMany(o => o.Personnels).WithMany(
        p => p.Operations).UsingEntity(t => t.ToTable("Membre"));
    
    //One To Many
    modelBuilder.Entity<Product>().HasOne(p => p.MyCategory)
    .WithMany(c => c.Products)
    .HasForeignKey(p => p.CategoryId)
    .OnDelete(DeleteBehavior.ClientSetNull);
    OR 
    .OnDelete(DeleteBehavior.CASCADE);

    //rename table
    modelBuilder.Entity<Chirurgien>().ToTable("Chirurgien");
    
    modelBuilder.Entity<Personnel>().HasDiscriminator<char>("Type")
        .HasValue<Chirurgien>('C')
        .HasValue<Personnel>('P')
        .HasValue<EquipePluriDiciplinaire>('E');

    
    //gloabal config
    var stringProperties = modelBuilder.Model.GetEntityTypes().
        SelectMany(e => e.GetProperties())
        .Where(p => p.ClrType == typeof(DateTime)
        );
    foreach (var p in stringProperties)
    {
        //   p.ClrType = Datetime2;
    }  
    //global config pt2
    // Configurer toutes les proprietés qui commencent par Code comme clé primaire
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.Name.StartsWith("Code"))))
            {
                prop.IsPrimaryKey();
                // Configurer toutes les proprietés qui commence par code dans une colonne nommée code
                prop.SetColumnName("Code");
                // Configurer toutes les proprietés qui commence par code obligatoire
                prop.IsNullable = false;
            };
           

}
*/