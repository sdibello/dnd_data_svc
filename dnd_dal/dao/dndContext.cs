using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace dnd_dal.dao
{
    public partial class dndContext : DbContext
    {
        public dndContext()
        {
        }

        public dndContext(DbContextOptions<dndContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DndCharacterclass> DndCharacterclass { get; set; }
        public virtual DbSet<DndCharacterclassvariant> DndCharacterclassvariant { get; set; }
        public virtual DbSet<DndCharacterclassvariantClassSkills> DndCharacterclassvariantClassSkills { get; set; }
        public virtual DbSet<DndCharacterclassvariantrequiresfeat> DndCharacterclassvariantrequiresfeat { get; set; }
        public virtual DbSet<DndCharacterclassvariantrequiresrace> DndCharacterclassvariantrequiresrace { get; set; }
        public virtual DbSet<DndCharacterclassvariantrequiresskill> DndCharacterclassvariantrequiresskill { get; set; }
        public virtual DbSet<DndDeity> DndDeity { get; set; }
        public virtual DbSet<DndDndedition> DndDndedition { get; set; }
        public virtual DbSet<DndDomain> DndDomain { get; set; }
        public virtual DbSet<DndDomainvariant> DndDomainvariant { get; set; }
        public virtual DbSet<DndDomainvariantDeities> DndDomainvariantDeities { get; set; }
        public virtual DbSet<DndDomainvariantOtherDeities> DndDomainvariantOtherDeities { get; set; }
        public virtual DbSet<DndFeat> DndFeat { get; set; }
        public virtual DbSet<DndFeatFeatCategories> DndFeatFeatCategories { get; set; }
        public virtual DbSet<DndFeatcategory> DndFeatcategory { get; set; }
        public virtual DbSet<DndFeatrequiresfeat> DndFeatrequiresfeat { get; set; }
        public virtual DbSet<DndFeatrequiresskill> DndFeatrequiresskill { get; set; }
        public virtual DbSet<DndFeatspecialfeatprerequisite> DndFeatspecialfeatprerequisite { get; set; }
        public virtual DbSet<DndItem> DndItem { get; set; }
        public virtual DbSet<DndItemAuraSchools> DndItemAuraSchools { get; set; }
        public virtual DbSet<DndItemRequiredFeats> DndItemRequiredFeats { get; set; }
        public virtual DbSet<DndItemRequiredSpells> DndItemRequiredSpells { get; set; }
        public virtual DbSet<DndItemactivationtype> DndItemactivationtype { get; set; }
        public virtual DbSet<DndItemauratype> DndItemauratype { get; set; }
        public virtual DbSet<DndItemproperty> DndItemproperty { get; set; }
        public virtual DbSet<DndItemslot> DndItemslot { get; set; }
        public virtual DbSet<DndLanguage> DndLanguage { get; set; }
        public virtual DbSet<DndMonster> DndMonster { get; set; }
        public virtual DbSet<DndMonsterSubtypes> DndMonsterSubtypes { get; set; }
        public virtual DbSet<DndMonsterhasfeat> DndMonsterhasfeat { get; set; }
        public virtual DbSet<DndMonsterhasskill> DndMonsterhasskill { get; set; }
        public virtual DbSet<DndMonsterspeed> DndMonsterspeed { get; set; }
        public virtual DbSet<DndMonstersubtype> DndMonstersubtype { get; set; }
        public virtual DbSet<DndMonstertype> DndMonstertype { get; set; }
        public virtual DbSet<DndNewsentry> DndNewsentry { get; set; }
        public virtual DbSet<DndRace> DndRace { get; set; }
        public virtual DbSet<DndRaceAutomaticLanguages> DndRaceAutomaticLanguages { get; set; }
        public virtual DbSet<DndRaceBonusLanguages> DndRaceBonusLanguages { get; set; }
        public virtual DbSet<DndRacefavoredcharacterclass> DndRacefavoredcharacterclass { get; set; }
        public virtual DbSet<DndRacesize> DndRacesize { get; set; }
        public virtual DbSet<DndRacespeed> DndRacespeed { get; set; }
        public virtual DbSet<DndRacespeedtype> DndRacespeedtype { get; set; }
        public virtual DbSet<DndRacetype> DndRacetype { get; set; }
        public virtual DbSet<DndRule> DndRule { get; set; }
        public virtual DbSet<DndRulebook> DndRulebook { get; set; }
        public virtual DbSet<DndRulesConditions> DndRulesConditions { get; set; }
        public virtual DbSet<DndSkill> DndSkill { get; set; }
        public virtual DbSet<DndSkillvariant> DndSkillvariant { get; set; }
        public virtual DbSet<DndSpecialfeatprerequisite> DndSpecialfeatprerequisite { get; set; }
        public virtual DbSet<DndSpell> DndSpell { get; set; }
        public virtual DbSet<DndSpellDescriptors> DndSpellDescriptors { get; set; }
        public virtual DbSet<DndSpellclasslevel> DndSpellclasslevel { get; set; }
        public virtual DbSet<DndSpelldescriptor> DndSpelldescriptor { get; set; }
        public virtual DbSet<DndSpelldomainlevel> DndSpelldomainlevel { get; set; }
        public virtual DbSet<DndSpellschool> DndSpellschool { get; set; }
        public virtual DbSet<DndSpellsubschool> DndSpellsubschool { get; set; }
        public virtual DbSet<DndStaticpage> DndStaticpage { get; set; }
        public virtual DbSet<DndTextfeatprerequisite> DndTextfeatprerequisite { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("DataSource=D:\\git\\dnd_graphQL_svc\\dnd_graphql_svc\\Data\\dnd.sqlite");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DndCharacterclass>(entity =>
            {
                entity.ToTable("dnd_characterclass");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_characterclass_dnd_characterclass_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_characterclass_dnd_characterclass_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Prestige)
                    .HasColumnName("prestige")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ShortDescription)
                    .IsRequired()
                    .HasColumnName("short_description")
                    .HasColumnType("longtext");

                entity.Property(e => e.ShortDescriptionHtml)
                    .IsRequired()
                    .HasColumnName("short_description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndCharacterclassvariant>(entity =>
            {
                entity.ToTable("dnd_characterclassvariant");

                entity.HasIndex(e => e.CharacterClassId)
                    .HasName("dnd_characterclassvariant_dnd_characterclassvariant_4d1287f7");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_characterclassvariant_dnd_characterclassvariant_51956a35");

                entity.HasIndex(e => new { e.RulebookId, e.CharacterClassId })
                    .HasName("dnd_characterclassvariant_dnd_characterclassvariant_rulebook_id_69a6fb11587c030e_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Advancement)
                    .IsRequired()
                    .HasColumnName("advancement")
                    .HasColumnType("longtext");

                entity.Property(e => e.AdvancementHtml)
                    .IsRequired()
                    .HasColumnName("advancement_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Alignment)
                    .IsRequired()
                    .HasColumnName("alignment")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.CharacterClassId)
                    .HasColumnName("character_class_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ClassFeatures)
                    .IsRequired()
                    .HasColumnName("class_features")
                    .HasColumnType("longtext");

                entity.Property(e => e.ClassFeaturesHtml)
                    .IsRequired()
                    .HasColumnName("class_features_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.HitDie)
                    .HasColumnName("hit_die")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.RequiredBab)
                    .HasColumnName("required_bab")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Requirements)
                    .IsRequired()
                    .HasColumnName("requirements")
                    .HasColumnType("longtext");

                entity.Property(e => e.RequirementsHtml)
                    .IsRequired()
                    .HasColumnName("requirements_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SkillPoints)
                    .HasColumnName("skill_points")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.StartingGold)
                    .IsRequired()
                    .HasColumnName("starting_gold")
                    .HasColumnType("varchar(32)");

                entity.HasOne(d => d.CharacterClass)
                    .WithMany(p => p.DndCharacterclassvariant)
                    .HasForeignKey(d => d.CharacterClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndCharacterclassvariant)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndCharacterclassvariantClassSkills>(entity =>
            {
                entity.ToTable("dnd_characterclassvariant_class_skills");

                entity.HasIndex(e => e.CharacterclassvariantId)
                    .HasName("dnd_characterclassvariant_class_skills_dnd_characterclassvariant_class_skills_62519975");

                entity.HasIndex(e => e.SkillId)
                    .HasName("dnd_characterclassvariant_class_skills_dnd_characterclassvariant_class_skills_30f70346");

                entity.HasIndex(e => new { e.CharacterclassvariantId, e.SkillId })
                    .HasName("dnd_characterclassvariant_class_skills_dnd_charactercla_characterclassvariant_id_594218372f051506_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterclassvariantId)
                    .HasColumnName("characterclassvariant_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Characterclassvariant)
                    .WithMany(p => p.DndCharacterclassvariantClassSkills)
                    .HasForeignKey(d => d.CharacterclassvariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.DndCharacterclassvariantClassSkills)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndCharacterclassvariantrequiresfeat>(entity =>
            {
                entity.ToTable("dnd_characterclassvariantrequiresfeat");

                entity.HasIndex(e => e.CharacterClassVariantId)
                    .HasName("dnd_characterclassvariantrequiresfeat_dnd_characterclassvariantrequiresfeat_433a4f0b");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_characterclassvariantrequiresfeat_dnd_characterclassvariantrequiresfeat_2f59e7d8");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterClassVariantId)
                    .HasColumnName("character_class_variant_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RemoveComma)
                    .HasColumnName("remove_comma")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TextAfter)
                    .IsRequired()
                    .HasColumnName("text_after")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.TextBefore)
                    .IsRequired()
                    .HasColumnName("text_before")
                    .HasColumnType("varchar(64)");

                entity.HasOne(d => d.CharacterClassVariant)
                    .WithMany(p => p.DndCharacterclassvariantrequiresfeat)
                    .HasForeignKey(d => d.CharacterClassVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndCharacterclassvariantrequiresfeat)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndCharacterclassvariantrequiresrace>(entity =>
            {
                entity.ToTable("dnd_characterclassvariantrequiresrace");

                entity.HasIndex(e => e.CharacterClassVariantId)
                    .HasName("dnd_characterclassvariantrequiresrace_dnd_characterclassvariantrequiresrace_433a4f0b");

                entity.HasIndex(e => e.RaceId)
                    .HasName("dnd_characterclassvariantrequiresrace_dnd_characterclassvariantrequiresrace_3548c065");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterClassVariantId)
                    .HasColumnName("character_class_variant_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.RaceId)
                    .HasColumnName("race_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RemoveComma)
                    .HasColumnName("remove_comma")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TextAfter)
                    .IsRequired()
                    .HasColumnName("text_after")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.TextBefore)
                    .IsRequired()
                    .HasColumnName("text_before")
                    .HasColumnType("varchar(64)");

                entity.HasOne(d => d.CharacterClassVariant)
                    .WithMany(p => p.DndCharacterclassvariantrequiresrace)
                    .HasForeignKey(d => d.CharacterClassVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DndCharacterclassvariantrequiresrace)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndCharacterclassvariantrequiresskill>(entity =>
            {
                entity.ToTable("dnd_characterclassvariantrequiresskill");

                entity.HasIndex(e => e.CharacterClassVariantId)
                    .HasName("dnd_characterclassvariantrequiresskill_dnd_characterclassvariantrequiresskill_433a4f0b");

                entity.HasIndex(e => e.SkillId)
                    .HasName("dnd_characterclassvariantrequiresskill_dnd_characterclassvariantrequiresskill_30f70346");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterClassVariantId)
                    .HasColumnName("character_class_variant_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Ranks)
                    .HasColumnName("ranks")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.RemoveComma)
                    .HasColumnName("remove_comma")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TextAfter)
                    .IsRequired()
                    .HasColumnName("text_after")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.TextBefore)
                    .IsRequired()
                    .HasColumnName("text_before")
                    .HasColumnType("varchar(64)");

                entity.HasOne(d => d.CharacterClassVariant)
                    .WithMany(p => p.DndCharacterclassvariantrequiresskill)
                    .HasForeignKey(d => d.CharacterClassVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.DndCharacterclassvariantrequiresskill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndDeity>(entity =>
            {
                entity.ToTable("dnd_deity");

                entity.HasIndex(e => e.FavoredWeaponId)
                    .HasName("dnd_deity_dnd_deity_42d3ba94");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_deity_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_deity_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Alignment)
                    .IsRequired()
                    .HasColumnName("alignment")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.FavoredWeaponId)
                    .HasColumnName("favored_weapon_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");

                entity.HasOne(d => d.FavoredWeapon)
                    .WithMany(p => p.DndDeity)
                    .HasForeignKey(d => d.FavoredWeaponId);
            });

            modelBuilder.Entity<DndDndedition>(entity =>
            {
                entity.ToTable("dnd_dndedition");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_dndedition_dnd_dndedition_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_dndedition_dnd_dndedition_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Core)
                    .HasColumnName("core")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.System)
                    .IsRequired()
                    .HasColumnName("system")
                    .HasColumnType("varchar(16)");
            });

            modelBuilder.Entity<DndDomain>(entity =>
            {
                entity.ToTable("dnd_domain");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_domain_dnd_domain_name_uniq");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_domain_dnd_domain_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndDomainvariant>(entity =>
            {
                entity.ToTable("dnd_domainvariant");

                entity.HasIndex(e => e.DomainId)
                    .HasName("dnd_domainvariant_dnd_domainvariant_a2431ea");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_domainvariant_dnd_domainvariant_51956a35");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeitiesText)
                    .IsRequired()
                    .HasColumnName("deities_text")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.DomainId)
                    .HasColumnName("domain_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GrantedPower)
                    .IsRequired()
                    .HasColumnName("granted_power")
                    .HasColumnType("longtext");

                entity.Property(e => e.GrantedPowerHtml)
                    .IsRequired()
                    .HasColumnName("granted_power_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.GrantedPowerType)
                    .IsRequired()
                    .HasColumnName("granted_power_type")
                    .HasColumnType("varchar(8)");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Requirement)
                    .IsRequired()
                    .HasColumnName("requirement")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.DndDomainvariant)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndDomainvariant)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndDomainvariantDeities>(entity =>
            {
                entity.ToTable("dnd_domainvariant_deities");

                entity.HasIndex(e => e.DeityId)
                    .HasName("dnd_domainvariant_deities_dnd_domainvariant_deities_27307746");

                entity.HasIndex(e => e.DomainvariantId)
                    .HasName("dnd_domainvariant_deities_dnd_domainvariant_deities_226d9ee2");

                entity.HasIndex(e => new { e.DomainvariantId, e.DeityId })
                    .HasName("dnd_domainvariant_deities_dnd_domainvariant_deities_domainvariant_id_e102dfb14ee5c6d_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeityId)
                    .HasColumnName("deity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DomainvariantId)
                    .HasColumnName("domainvariant_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Deity)
                    .WithMany(p => p.DndDomainvariantDeities)
                    .HasForeignKey(d => d.DeityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Domainvariant)
                    .WithMany(p => p.DndDomainvariantDeities)
                    .HasForeignKey(d => d.DomainvariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndDomainvariantOtherDeities>(entity =>
            {
                entity.ToTable("dnd_domainvariant_other_deities");

                entity.HasIndex(e => e.DeityId)
                    .HasName("dnd_domainvariant_other_deities_dnd_domainvariant_other_deities_27307746");

                entity.HasIndex(e => e.DomainvariantId)
                    .HasName("dnd_domainvariant_other_deities_dnd_domainvariant_other_deities_226d9ee2");

                entity.HasIndex(e => new { e.DomainvariantId, e.DeityId })
                    .HasName("dnd_domainvariant_other_deities_dnd_domainvariant_other_d_domainvariant_id_a674a18dfab6630_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeityId)
                    .HasColumnName("deity_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DomainvariantId)
                    .HasColumnName("domainvariant_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Deity)
                    .WithMany(p => p.DndDomainvariantOtherDeities)
                    .HasForeignKey(d => d.DeityId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Domainvariant)
                    .WithMany(p => p.DndDomainvariantOtherDeities)
                    .HasForeignKey(d => d.DomainvariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndFeat>(entity =>
            {
                entity.ToTable("dnd_feat");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_feat_dnd_feat_name");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_feat_dnd_feat_51956a35");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_feat_dnd_feat_a951d5d6");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Benefit)
                    .IsRequired()
                    .HasColumnName("benefit")
                    .HasColumnType("longtext");

                entity.Property(e => e.BenefitHtml)
                    .IsRequired()
                    .HasColumnName("benefit_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Normal)
                    .IsRequired()
                    .HasColumnName("normal")
                    .HasColumnType("longtext");

                entity.Property(e => e.NormalHtml)
                    .IsRequired()
                    .HasColumnName("normal_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Special)
                    .IsRequired()
                    .HasColumnName("special")
                    .HasColumnType("longtext");

                entity.Property(e => e.SpecialHtml)
                    .IsRequired()
                    .HasColumnName("special_html")
                    .HasColumnType("longtext");

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndFeat)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndFeatFeatCategories>(entity =>
            {
                entity.ToTable("dnd_feat_feat_categories");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_feat_feat_categories_dnd_feat_feat_categories_2f59e7d8");

                entity.HasIndex(e => e.FeatcategoryId)
                    .HasName("dnd_feat_feat_categories_dnd_feat_feat_categories_5509d08");

                entity.HasIndex(e => new { e.FeatId, e.FeatcategoryId })
                    .HasName("dnd_feat_feat_categories_dnd_feat_feat_categories_feat_id_3a0b9d0392305885_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FeatcategoryId)
                    .HasColumnName("featcategory_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndFeatFeatCategories)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Featcategory)
                    .WithMany(p => p.DndFeatFeatCategories)
                    .HasForeignKey(d => d.FeatcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndFeatcategory>(entity =>
            {
                entity.ToTable("dnd_featcategory");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_featcategory_dnd_featcategory_name_uniq");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_featcategory_dnd_featcategory_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndFeatrequiresfeat>(entity =>
            {
                entity.ToTable("dnd_featrequiresfeat");

                entity.HasIndex(e => e.RequiredFeatId)
                    .HasName("dnd_featrequiresfeat_dnd_featrequiresfeat_8238d861");

                entity.HasIndex(e => e.SourceFeatId)
                    .HasName("dnd_featrequiresfeat_dnd_featrequiresfeat_dc102e93");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdditionalText)
                    .IsRequired()
                    .HasColumnName("additional_text")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.RequiredFeatId)
                    .HasColumnName("required_feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SourceFeatId)
                    .HasColumnName("source_feat_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.RequiredFeat)
                    .WithMany(p => p.DndFeatrequiresfeatRequiredFeat)
                    .HasForeignKey(d => d.RequiredFeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SourceFeat)
                    .WithMany(p => p.DndFeatrequiresfeatSourceFeat)
                    .HasForeignKey(d => d.SourceFeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndFeatrequiresskill>(entity =>
            {
                entity.ToTable("dnd_featrequiresskill");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_featrequiresskill_dnd_featrequiresskill_2f59e7d8");

                entity.HasIndex(e => e.SkillId)
                    .HasName("dnd_featrequiresskill_dnd_featrequiresskill_30f70346");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MinRank)
                    .HasColumnName("min_rank")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndFeatrequiresskill)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.DndFeatrequiresskill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndFeatspecialfeatprerequisite>(entity =>
            {
                entity.ToTable("dnd_featspecialfeatprerequisite");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_featspecialfeatprerequisite_dnd_featspecialfeatprerequisite_2f59e7d8");

                entity.HasIndex(e => e.SpecialFeatPrerequisiteId)
                    .HasName("dnd_featspecialfeatprerequisite_dnd_featspecialfeatprerequisite_c2048d74");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpecialFeatPrerequisiteId)
                    .HasColumnName("special_feat_prerequisite_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value1)
                    .IsRequired()
                    .HasColumnName("value_1")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Value2)
                    .IsRequired()
                    .HasColumnName("value_2")
                    .HasColumnType("varchar(256)");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndFeatspecialfeatprerequisite)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SpecialFeatPrerequisite)
                    .WithMany(p => p.DndFeatspecialfeatprerequisite)
                    .HasForeignKey(d => d.SpecialFeatPrerequisiteId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndItem>(entity =>
            {
                entity.ToTable("dnd_item");

                entity.HasIndex(e => e.ActivationId)
                    .HasName("dnd_item_dnd_item_a7ff055e");

                entity.HasIndex(e => e.AuraId)
                    .HasName("dnd_item_dnd_item_c181fb11");

                entity.HasIndex(e => e.BodySlotId)
                    .HasName("dnd_item_dnd_item_35a44c52");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_item_dnd_item_52094d6e");

                entity.HasIndex(e => e.PropertyId)
                    .HasName("dnd_item_dnd_item_6a812853");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_item_dnd_item_51956a35");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_item_slug");

                entity.HasIndex(e => e.SynergyPrerequisiteId)
                    .HasName("dnd_item_dnd_item_ed720ca8");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivationId)
                    .HasColumnName("activation_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.AuraDc)
                    .IsRequired()
                    .HasColumnName("aura_dc")
                    .HasColumnType("varchar(16)");

                entity.Property(e => e.AuraId)
                    .HasColumnName("aura_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BodySlotId)
                    .HasColumnName("body_slot_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CasterLevel)
                    .HasColumnName("caster_level")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.CostToCreate)
                    .IsRequired()
                    .HasColumnName("cost_to_create")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.ItemLevel)
                    .HasColumnName("item_level")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.PriceBonus)
                    .HasColumnName("price_bonus")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.PriceGp)
                    .HasColumnName("price_gp")
                    .HasColumnType("int(10)");

                entity.Property(e => e.PropertyId)
                    .HasColumnName("property_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RequiredExtra)
                    .IsRequired()
                    .HasColumnName("required_extra")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SynergyPrerequisiteId)
                    .HasColumnName("synergy_prerequisite_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.VisualDescription)
                    .IsRequired()
                    .HasColumnName("visual_description")
                    .HasColumnType("longtext");

                entity.Property(e => e.Weight)
                    .HasColumnName("weight")
                    .HasColumnType("double");

                entity.HasOne(d => d.Activation)
                    .WithMany(p => p.DndItem)
                    .HasForeignKey(d => d.ActivationId);

                entity.HasOne(d => d.Aura)
                    .WithMany(p => p.DndItem)
                    .HasForeignKey(d => d.AuraId);

                entity.HasOne(d => d.BodySlot)
                    .WithMany(p => p.DndItem)
                    .HasForeignKey(d => d.BodySlotId);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.DndItem)
                    .HasForeignKey(d => d.PropertyId);

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndItem)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SynergyPrerequisite)
                    .WithMany(p => p.InverseSynergyPrerequisite)
                    .HasForeignKey(d => d.SynergyPrerequisiteId);
            });

            modelBuilder.Entity<DndItemAuraSchools>(entity =>
            {
                entity.ToTable("dnd_item_aura_schools");

                entity.HasIndex(e => e.ItemId)
                    .HasName("dnd_item_aura_schools_dnd_item_aura_schools_67b70d25");

                entity.HasIndex(e => e.SpellschoolId)
                    .HasName("dnd_item_aura_schools_dnd_item_aura_schools_a7db21ef");

                entity.HasIndex(e => new { e.ItemId, e.SpellschoolId })
                    .HasName("dnd_item_aura_schools_dnd_item_aura_schools_item_id_345bdf3601d7f155_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpellschoolId)
                    .HasColumnName("spellschool_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.DndItemAuraSchools)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Spellschool)
                    .WithMany(p => p.DndItemAuraSchools)
                    .HasForeignKey(d => d.SpellschoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndItemRequiredFeats>(entity =>
            {
                entity.ToTable("dnd_item_required_feats");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_item_required_feats_dnd_item_required_feats_2f59e7d8");

                entity.HasIndex(e => e.ItemId)
                    .HasName("dnd_item_required_feats_dnd_item_required_feats_67b70d25");

                entity.HasIndex(e => new { e.ItemId, e.FeatId })
                    .HasName("dnd_item_required_feats_dnd_item_required_feats_item_id_86ffea90e89a0f2_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndItemRequiredFeats)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.DndItemRequiredFeats)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndItemRequiredSpells>(entity =>
            {
                entity.ToTable("dnd_item_required_spells");

                entity.HasIndex(e => e.ItemId)
                    .HasName("dnd_item_required_spells_dnd_item_required_spells_67b70d25");

                entity.HasIndex(e => e.SpellId)
                    .HasName("dnd_item_required_spells_dnd_item_required_spells_a091809d");

                entity.HasIndex(e => new { e.ItemId, e.SpellId })
                    .HasName("dnd_item_required_spells_dnd_item_required_spells_item_id_4420551901ef62b4_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.DndItemRequiredSpells)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.DndItemRequiredSpells)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndItemactivationtype>(entity =>
            {
                entity.ToTable("dnd_itemactivationtype");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_itemactivationtype_dnd_itemactivationtype_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_itemactivationtype_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndItemauratype>(entity =>
            {
                entity.ToTable("dnd_itemauratype");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_itemauratype_dnd_itemauratype_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_itemauratype_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndItemproperty>(entity =>
            {
                entity.ToTable("dnd_itemproperty");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_itemproperty_dnd_itemproperty_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_itemproperty_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndItemslot>(entity =>
            {
                entity.ToTable("dnd_itemslot");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_itemslot_dnd_itemslot_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_itemslot_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndLanguage>(entity =>
            {
                entity.ToTable("dnd_language");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_language_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndMonster>(entity =>
            {
                entity.ToTable("dnd_monster");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_monster_dnd_monster_52094d6e");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_monster_dnd_monster_51956a35");

                entity.HasIndex(e => e.SizeId)
                    .HasName("dnd_monster_dnd_monster_6154b20f");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_monster_dnd_monster_a951d5d6");

                entity.HasIndex(e => e.TypeId)
                    .HasName("dnd_monster_dnd_monster_777d41c8");

                entity.HasIndex(e => new { e.Name, e.RulebookId })
                    .HasName("dnd_monster_dnd_monster_name_5810a781de09be1f_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Advancement)
                    .IsRequired()
                    .HasColumnName("advancement")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Alignment)
                    .IsRequired()
                    .HasColumnName("alignment")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.ArmorClass)
                    .IsRequired()
                    .HasColumnName("armor_class")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'32 (–1 size, +4 Dex, +19 natural)'");

                entity.Property(e => e.Attack)
                    .IsRequired()
                    .HasColumnName("attack")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'+3 greatsword +23 melee (3d6+13/19–20) or slam +20 melee (2d8+10)'");

                entity.Property(e => e.BaseAttack)
                    .HasColumnName("base_attack")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Cha)
                    .HasColumnName("cha")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ChallengeRating)
                    .HasColumnName("challenge_rating")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Combat)
                    .IsRequired()
                    .HasColumnName("combat")
                    .HasColumnType("longtext");

                entity.Property(e => e.CombatHtml)
                    .IsRequired()
                    .HasColumnName("combat_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Con)
                    .HasColumnName("con")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Dex)
                    .HasColumnName("dex")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Environment)
                    .IsRequired()
                    .HasColumnName("environment")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.FlatFootedArmorClass)
                    .HasColumnName("flat_footed_armor_class")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FortSave)
                    .HasColumnName("fort_save")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FortSaveExtra)
                    .IsRequired()
                    .HasColumnName("fort_save_extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.FullAttack)
                    .IsRequired()
                    .HasColumnName("full_attack")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'+3 greatsword +23/+18/+13 melee (3d6+13/19–20) or slam +20 melee (2d8+10)'");

                entity.Property(e => e.Grapple)
                    .HasColumnName("grapple")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.HitDice)
                    .IsRequired()
                    .HasColumnName("hit_dice")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Initiative)
                    .HasColumnName("initiative")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Int)
                    .HasColumnName("int")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LevelAdjustment)
                    .HasColumnName("level_adjustment")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasColumnName("organization")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Reach)
                    .HasColumnName("reach")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.ReflexSave)
                    .HasColumnName("reflex_save")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.ReflexSaveExtra)
                    .IsRequired()
                    .HasColumnName("reflex_save_extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SizeId)
                    .HasColumnName("size_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Space)
                    .HasColumnName("space")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.SpecialAttacks)
                    .IsRequired()
                    .HasColumnName("special_attacks")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.SpecialQualities)
                    .IsRequired()
                    .HasColumnName("special_qualities")
                    .HasColumnType("varchar(512)");

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.TouchArmorClass)
                    .HasColumnName("touch_armor_class")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Treasure)
                    .IsRequired()
                    .HasColumnName("treasure")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WillSave)
                    .HasColumnName("will_save")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.WillSaveExtra)
                    .IsRequired()
                    .HasColumnName("will_save_extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Wis)
                    .HasColumnName("wis")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndMonster)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.DndMonster)
                    .HasForeignKey(d => d.SizeId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DndMonster)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndMonsterSubtypes>(entity =>
            {
                entity.ToTable("dnd_monster_subtypes");

                entity.HasIndex(e => e.MonsterId)
                    .HasName("dnd_monster_subtypes_dnd_monster_subtypes_6608660b");

                entity.HasIndex(e => e.MonstersubtypeId)
                    .HasName("dnd_monster_subtypes_dnd_monster_subtypes_3c3013de");

                entity.HasIndex(e => new { e.MonsterId, e.MonstersubtypeId })
                    .HasName("dnd_monster_subtypes_dnd_monster_subtypes_monster_id_7716d36de2720dc0_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.MonsterId)
                    .HasColumnName("monster_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MonstersubtypeId)
                    .HasColumnName("monstersubtype_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.DndMonsterSubtypes)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Monstersubtype)
                    .WithMany(p => p.DndMonsterSubtypes)
                    .HasForeignKey(d => d.MonstersubtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndMonsterhasfeat>(entity =>
            {
                entity.ToTable("dnd_monsterhasfeat");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_monsterhasfeat_dnd_monsterhasfeat_2f59e7d8");

                entity.HasIndex(e => e.MonsterId)
                    .HasName("dnd_monsterhasfeat_dnd_monsterhasfeat_6608660b");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MonsterId)
                    .HasColumnName("monster_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndMonsterhasfeat)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.DndMonsterhasfeat)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndMonsterhasskill>(entity =>
            {
                entity.ToTable("dnd_monsterhasskill");

                entity.HasIndex(e => e.MonsterId)
                    .HasName("dnd_monsterhasskill_dnd_monsterhasskill_6608660b");

                entity.HasIndex(e => e.SkillId)
                    .HasName("dnd_monsterhasskill_dnd_monsterhasskill_30f70346");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.MonsterId)
                    .HasColumnName("monster_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ranks)
                    .HasColumnName("ranks")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Monster)
                    .WithMany(p => p.DndMonsterhasskill)
                    .HasForeignKey(d => d.MonsterId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.DndMonsterhasskill)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndMonsterspeed>(entity =>
            {
                entity.ToTable("dnd_monsterspeed");

                entity.HasIndex(e => e.RaceId)
                    .HasName("dnd_monsterspeed_dnd_monsterspeed_3548c065");

                entity.HasIndex(e => e.TypeId)
                    .HasName("dnd_monsterspeed_dnd_monsterspeed_777d41c8");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.RaceId)
                    .HasColumnName("race_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DndMonsterspeed)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DndMonsterspeed)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndMonstersubtype>(entity =>
            {
                entity.ToTable("dnd_monstersubtype");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_monstersubtype_dnd_monstersubtype_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_monstersubtype_dnd_monstersubtype_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndMonstertype>(entity =>
            {
                entity.ToTable("dnd_monstertype");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_monstertype_dnd_monstertype_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_monstertype_dnd_monstertype_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndNewsentry>(entity =>
            {
                entity.ToTable("dnd_newsentry");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("longtext");

                entity.Property(e => e.BodyHtml)
                    .IsRequired()
                    .HasColumnName("body_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Enabled)
                    .HasColumnName("enabled")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasColumnName("published")
                    .HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndRace>(entity =>
            {
                entity.ToTable("dnd_race");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_race_dnd_race_52094d6e");

                entity.HasIndex(e => e.RaceTypeId)
                    .HasName("dnd_race_dnd_race_34628d95");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_race_dnd_race_51956a35");

                entity.HasIndex(e => e.SizeId)
                    .HasName("dnd_race_dnd_race_6154b20f");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_race_dnd_race_a951d5d6");

                entity.HasIndex(e => new { e.Name, e.RulebookId })
                    .HasName("dnd_race_dnd_race_name_64b932b074325211_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cha)
                    .HasColumnName("cha")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Combat)
                    .IsRequired()
                    .HasColumnName("combat")
                    .HasColumnType("longtext");

                entity.Property(e => e.CombatHtml)
                    .IsRequired()
                    .HasColumnName("combat_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Con)
                    .HasColumnName("con")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Dex)
                    .HasColumnName("dex")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Int)
                    .HasColumnName("int")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.LevelAdjustment)
                    .HasColumnName("level_adjustment")
                    .HasColumnType("smallint(6)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.NaturalArmor)
                    .HasColumnName("natural_armor")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.RaceTypeId)
                    .HasColumnName("race_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RacialHitDiceCount)
                    .HasColumnName("racial_hit_dice_count")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.RacialTraits)
                    .IsRequired()
                    .HasColumnName("racial_traits")
                    .HasColumnType("longtext");

                entity.Property(e => e.RacialTraitsHtml)
                    .IsRequired()
                    .HasColumnName("racial_traits_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Reach)
                    .HasColumnName("reach")
                    .HasColumnType("smallint(5)")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SizeId)
                    .HasColumnName("size_id")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Space)
                    .HasColumnName("space")
                    .HasColumnType("smallint(5)")
                    .HasDefaultValueSql("'5'");

                entity.Property(e => e.Str)
                    .HasColumnName("str")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.Wis)
                    .HasColumnName("wis")
                    .HasColumnType("smallint(6)");

                entity.HasOne(d => d.RaceType)
                    .WithMany(p => p.DndRace)
                    .HasForeignKey(d => d.RaceTypeId);

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndRace)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.DndRace)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRaceAutomaticLanguages>(entity =>
            {
                entity.ToTable("dnd_race_automatic_languages");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("dnd_race_automatic_languages_dnd_race_automatic_languages_7ab48146");

                entity.HasIndex(e => e.RaceId)
                    .HasName("dnd_race_automatic_languages_dnd_race_automatic_languages_3548c065");

                entity.HasIndex(e => new { e.RaceId, e.LanguageId })
                    .HasName("dnd_race_automatic_languages_dnd_race_automatic_languages_race_id_4ef05d055298a9df_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RaceId)
                    .HasColumnName("race_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DndRaceAutomaticLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DndRaceAutomaticLanguages)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRaceBonusLanguages>(entity =>
            {
                entity.ToTable("dnd_race_bonus_languages");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("dnd_race_bonus_languages_dnd_race_bonus_languages_7ab48146");

                entity.HasIndex(e => e.RaceId)
                    .HasName("dnd_race_bonus_languages_dnd_race_bonus_languages_3548c065");

                entity.HasIndex(e => new { e.RaceId, e.LanguageId })
                    .HasName("dnd_race_bonus_languages_dnd_race_bonus_languages_race_id_1922bed42ad1b62b_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RaceId)
                    .HasColumnName("race_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.DndRaceBonusLanguages)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DndRaceBonusLanguages)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRacefavoredcharacterclass>(entity =>
            {
                entity.ToTable("dnd_racefavoredcharacterclass");

                entity.HasIndex(e => e.CharacterClassId)
                    .HasName("dnd_racefavoredcharacterclass_dnd_racefavoredcharacterclass_4d1287f7");

                entity.HasIndex(e => e.RaceId)
                    .HasName("dnd_racefavoredcharacterclass_dnd_racefavoredcharacterclass_3548c065");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterClassId)
                    .HasColumnName("character_class_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.RaceId)
                    .HasColumnName("race_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CharacterClass)
                    .WithMany(p => p.DndRacefavoredcharacterclass)
                    .HasForeignKey(d => d.CharacterClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DndRacefavoredcharacterclass)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRacesize>(entity =>
            {
                entity.ToTable("dnd_racesize");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_racesize_dnd_racesize_52094d6e");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("smallint(5)");
            });

            modelBuilder.Entity<DndRacespeed>(entity =>
            {
                entity.ToTable("dnd_racespeed");

                entity.HasIndex(e => e.RaceId)
                    .HasName("dnd_racespeed_dnd_racespeed_3548c065");

                entity.HasIndex(e => e.TypeId)
                    .HasName("dnd_racespeed_dnd_racespeed_777d41c8");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.RaceId)
                    .HasColumnName("race_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Speed)
                    .HasColumnName("speed")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Race)
                    .WithMany(p => p.DndRacespeed)
                    .HasForeignKey(d => d.RaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.DndRacespeed)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRacespeedtype>(entity =>
            {
                entity.ToTable("dnd_racespeedtype");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_racespeedtype_dnd_racespeedtype_52094d6e");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Extra)
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndRacetype>(entity =>
            {
                entity.ToTable("dnd_racetype");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_racetype_dnd_racetype_52094d6e");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_racetype_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseAttackType)
                    .IsRequired()
                    .HasColumnName("base_attack_type")
                    .HasColumnType("varchar(3)");

                entity.Property(e => e.BaseFortSaveType)
                    .IsRequired()
                    .HasColumnName("base_fort_save_type")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.BaseReflexSaveType)
                    .IsRequired()
                    .HasColumnName("base_reflex_save_type")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.BaseWillSaveType)
                    .IsRequired()
                    .HasColumnName("base_will_save_type")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.HitDieSize)
                    .HasColumnName("hit_die_size")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndRule>(entity =>
            {
                entity.ToTable("dnd_rule");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_rule_dnd_rule_52094d6e");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_rule_dnd_rule_51956a35");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_rule_slug");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("longtext");

                entity.Property(e => e.BodyHtml)
                    .IsRequired()
                    .HasColumnName("body_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.PageFrom)
                    .HasColumnName("page_from")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.PageTo)
                    .HasColumnName("page_to")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndRule)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRulebook>(entity =>
            {
                entity.ToTable("dnd_rulebook");

                entity.HasIndex(e => e.DndEditionId)
                    .HasName("dnd_rulebook_dnd_rulebook_66a88bda");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_rulebook_dnd_rulebook_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_rulebook_dnd_rulebook_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbr)
                    .IsRequired()
                    .HasColumnName("abbr")
                    .HasColumnType("varchar(7)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DndEditionId)
                    .HasColumnName("dnd_edition_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Image)
                    .HasColumnName("image")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.OfficialUrl)
                    .IsRequired()
                    .HasColumnName("official_url")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Published)
                    .HasColumnName("published")
                    .HasColumnType("date");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Year)
                    .HasColumnName("year")
                    .HasColumnType("varchar(4)");

                entity.HasOne(d => d.DndEdition)
                    .WithMany(p => p.DndRulebook)
                    .HasForeignKey(d => d.DndEditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndRulesConditions>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dnd_rules_conditions");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<DndSkill>(entity =>
            {
                entity.ToTable("dnd_skill");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_skill_dnd_skill_name_uniq");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_skill_dnd_skill_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArmorCheckPenalty)
                    .HasColumnName("armor_check_penalty")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.BaseSkill)
                    .IsRequired()
                    .HasColumnName("base_skill")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.TrainedOnly)
                    .HasColumnName("trained_only")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<DndSkillvariant>(entity =>
            {
                entity.ToTable("dnd_skillvariant");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_skillvariant_dnd_skillvariant_51956a35");

                entity.HasIndex(e => e.SkillId)
                    .HasName("dnd_skillvariant_dnd_skillvariant_30f70346");

                entity.HasIndex(e => new { e.SkillId, e.RulebookId })
                    .HasName("dnd_skillvariant_dnd_skillvariant_skill_id_65a2ff28b87f4e1e_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action")
                    .HasColumnType("longtext");

                entity.Property(e => e.ActionHtml)
                    .IsRequired()
                    .HasColumnName("action_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Check)
                    .IsRequired()
                    .HasColumnName("check")
                    .HasColumnType("longtext");

                entity.Property(e => e.CheckHtml)
                    .IsRequired()
                    .HasColumnName("check_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Restriction)
                    .IsRequired()
                    .HasColumnName("restriction")
                    .HasColumnType("longtext");

                entity.Property(e => e.RestrictionHtml)
                    .IsRequired()
                    .HasColumnName("restriction_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SkillId)
                    .HasColumnName("skill_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Special)
                    .IsRequired()
                    .HasColumnName("special")
                    .HasColumnType("longtext");

                entity.Property(e => e.SpecialHtml)
                    .IsRequired()
                    .HasColumnName("special_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Synergy)
                    .IsRequired()
                    .HasColumnName("synergy")
                    .HasColumnType("longtext");

                entity.Property(e => e.SynergyHtml)
                    .IsRequired()
                    .HasColumnName("synergy_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.TryAgain)
                    .IsRequired()
                    .HasColumnName("try_again")
                    .HasColumnType("longtext");

                entity.Property(e => e.TryAgainHtml)
                    .IsRequired()
                    .HasColumnName("try_again_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Untrained)
                    .IsRequired()
                    .HasColumnName("untrained")
                    .HasColumnType("longtext");

                entity.Property(e => e.UntrainedHtml)
                    .IsRequired()
                    .HasColumnName("untrained_html")
                    .HasColumnType("longtext");

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndSkillvariant)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Skill)
                    .WithMany(p => p.DndSkillvariant)
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndSpecialfeatprerequisite>(entity =>
            {
                entity.ToTable("dnd_specialfeatprerequisite");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_specialfeatprerequisite_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.PrintFormat)
                    .IsRequired()
                    .HasColumnName("print_format")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndSpell>(entity =>
            {
                entity.ToTable("dnd_spell");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_spell_dnd_spell_name");

                entity.HasIndex(e => e.RulebookId)
                    .HasName("dnd_spell_dnd_spell_51956a35");

                entity.HasIndex(e => e.SchoolId)
                    .HasName("dnd_spell_dnd_spell_1ebdc00a");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_spell_dnd_spell_a951d5d6");

                entity.HasIndex(e => e.SubSchoolId)
                    .HasName("dnd_spell_dnd_spell_20f50c5d");

                entity.HasIndex(e => e.VerifiedAuthorId)
                    .HasName("dnd_spell_dnd_spell_63f7f931");

                entity.HasIndex(e => new { e.Name, e.RulebookId })
                    .HasName("dnd_spell_dnd_spell_name_496ee28f7dbb33a7_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Added)
                    .IsRequired()
                    .HasColumnName("added")
                    .HasColumnType("datetime");

                entity.Property(e => e.ArcaneFocusComponent)
                    .HasColumnName("arcane_focus_component")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Area)
                    .HasColumnName("area")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.CastingTime)
                    .HasColumnName("casting_time")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.CorruptComponent)
                    .HasColumnName("corrupt_component")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.CorruptLevel)
                    .HasColumnName("corrupt_level")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext");

                entity.Property(e => e.DescriptionHtml)
                    .IsRequired()
                    .HasColumnName("description_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.DivineFocusComponent)
                    .HasColumnName("divine_focus_component")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.Effect)
                    .HasColumnName("effect")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.ExtraComponents)
                    .HasColumnName("extra_components")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.MaterialComponent)
                    .HasColumnName("material_component")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MetaBreathComponent)
                    .HasColumnName("meta_breath_component")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Page)
                    .HasColumnName("page")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.Range)
                    .HasColumnName("range")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.RulebookId)
                    .HasColumnName("rulebook_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SavingThrow)
                    .HasColumnName("saving_throw")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.SchoolId)
                    .HasColumnName("school_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SomaticComponent)
                    .HasColumnName("somatic_component")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.SpellResistance)
                    .HasColumnName("spell_resistance")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.SubSchoolId)
                    .HasColumnName("sub_school_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Target)
                    .HasColumnName("target")
                    .HasColumnType("varchar(256)");

                entity.Property(e => e.TrueNameComponent)
                    .HasColumnName("true_name_component")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.VerbalComponent)
                    .HasColumnName("verbal_component")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Verified)
                    .HasColumnName("verified")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.VerifiedAuthorId)
                    .HasColumnName("verified_author_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VerifiedTime)
                    .HasColumnName("verified_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.XpComponent)
                    .HasColumnName("xp_component")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Rulebook)
                    .WithMany(p => p.DndSpell)
                    .HasForeignKey(d => d.RulebookId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.School)
                    .WithMany(p => p.DndSpell)
                    .HasForeignKey(d => d.SchoolId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.SubSchool)
                    .WithMany(p => p.DndSpell)
                    .HasForeignKey(d => d.SubSchoolId);
            });

            modelBuilder.Entity<DndSpellDescriptors>(entity =>
            {
                entity.ToTable("dnd_spell_descriptors");

                entity.HasIndex(e => e.SpellId)
                    .HasName("dnd_spell_descriptors_dnd_spell_descriptors_a091809d");

                entity.HasIndex(e => e.SpelldescriptorId)
                    .HasName("dnd_spell_descriptors_dnd_spell_descriptors_30529786");

                entity.HasIndex(e => new { e.SpellId, e.SpelldescriptorId })
                    .HasName("dnd_spell_descriptors_dnd_spell_descriptors_spell_id_dbd1aa136fb353e_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpelldescriptorId)
                    .HasColumnName("spelldescriptor_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.DndSpellDescriptors)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Spelldescriptor)
                    .WithMany(p => p.DndSpellDescriptors)
                    .HasForeignKey(d => d.SpelldescriptorId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndSpellclasslevel>(entity =>
            {
                entity.ToTable("dnd_spellclasslevel");

                entity.HasIndex(e => e.CharacterClassId)
                    .HasName("dnd_spellclasslevel_dnd_spellclasslevel_4d1287f7");

                entity.HasIndex(e => e.SpellId)
                    .HasName("dnd_spellclasslevel_dnd_spellclasslevel_a091809d");

                entity.HasIndex(e => new { e.CharacterClassId, e.SpellId })
                    .HasName("dnd_spellclasslevel_dnd_spellclasslevel_character_class_id_3ae23c8563a83798_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterClassId)
                    .HasColumnName("character_class_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CharacterClass)
                    .WithMany(p => p.DndSpellclasslevel)
                    .HasForeignKey(d => d.CharacterClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.DndSpellclasslevel)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndSpelldescriptor>(entity =>
            {
                entity.ToTable("dnd_spelldescriptor");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_spelldescriptor_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_spelldescriptor_dnd_spelldescriptor_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(64)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(64)");
            });

            modelBuilder.Entity<DndSpelldomainlevel>(entity =>
            {
                entity.ToTable("dnd_spelldomainlevel");

                entity.HasIndex(e => e.DomainId)
                    .HasName("dnd_spelldomainlevel_dnd_spelldomainlevel_a2431ea");

                entity.HasIndex(e => e.SpellId)
                    .HasName("dnd_spelldomainlevel_dnd_spelldomainlevel_a091809d");

                entity.HasIndex(e => new { e.DomainId, e.SpellId })
                    .HasName("dnd_spelldomainlevel_dnd_spelldomainlevel_domain_id_e7bf8594e3b6bda_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.DomainId)
                    .HasColumnName("domain_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Extra)
                    .IsRequired()
                    .HasColumnName("extra")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("smallint(5)");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Domain)
                    .WithMany(p => p.DndSpelldomainlevel)
                    .HasForeignKey(d => d.DomainId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Spell)
                    .WithMany(p => p.DndSpelldomainlevel)
                    .HasForeignKey(d => d.SpellId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DndSpellschool>(entity =>
            {
                entity.ToTable("dnd_spellschool");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_spellschool_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_spellschool_dnd_spellschool_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndSpellsubschool>(entity =>
            {
                entity.ToTable("dnd_spellsubschool");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_spellsubschool_name");

                entity.HasIndex(e => e.Slug)
                    .HasName("dnd_spellsubschool_dnd_spellsubschool_slug_uniq");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");

                entity.Property(e => e.Slug)
                    .IsRequired()
                    .HasColumnName("slug")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndStaticpage>(entity =>
            {
                entity.ToTable("dnd_staticpage");

                entity.HasIndex(e => e.Name)
                    .HasName("dnd_staticpage_name");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasColumnName("body")
                    .HasColumnType("longtext");

                entity.Property(e => e.BodyHtml)
                    .IsRequired()
                    .HasColumnName("body_html")
                    .HasColumnType("longtext");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(32)");
            });

            modelBuilder.Entity<DndTextfeatprerequisite>(entity =>
            {
                entity.ToTable("dnd_textfeatprerequisite");

                entity.HasIndex(e => e.FeatId)
                    .HasName("dnd_textfeatprerequisite_dnd_textfeatprerequisite_2f59e7d8");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

                entity.Property(e => e.FeatId)
                    .HasColumnName("feat_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnName("text")
                    .HasColumnType("varchar(256)");

                entity.HasOne(d => d.Feat)
                    .WithMany(p => p.DndTextfeatprerequisite)
                    .HasForeignKey(d => d.FeatId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
