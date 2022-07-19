using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountBaseCategorys",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBaseCategorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Branch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 751, DateTimeKind.Local).AddTicks(5788)),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Formats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayCountForRemind = table.Column<int>(nullable: false),
                    DeleteAfterDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserNotifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    RemindMeLater = table.Column<bool>(nullable: false),
                    DontRemindMeLater = table.Column<bool>(nullable: false),
                    RemindMeDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Freez = table.Column<bool>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 745, DateTimeKind.Local).AddTicks(5947)),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    AccountBaseCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountCategory_AccountBaseCategorys_AccountBaseCategoryId",
                        column: x => x.AccountBaseCategoryId,
                        principalTable: "AccountBaseCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountCategory_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticaleCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticaleCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticaleCategory_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 753, DateTimeKind.Local).AddTicks(5733)),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Company_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Connection",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HostId = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false),
                    ComputerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connection_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 752, DateTimeKind.Local).AddTicks(5762)),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitType_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Year",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 751, DateTimeKind.Local).AddTicks(5788)),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Year", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Year_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 744, DateTimeKind.Local).AddTicks(5974)),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    LastName = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Description = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Tel = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Tel2 = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Address = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Address2 = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    General = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    AccountGeneralId = table.Column<int>(nullable: true),
                    AccountState = table.Column<int>(nullable: false),
                    AccountCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_AccountCategory_AccountCategoryId",
                        column: x => x.AccountCategoryId,
                        principalTable: "AccountCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Account_AccountGeneralId",
                        column: x => x.AccountGeneralId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_AccountBaseCategorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AccountBaseCategorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    EnglishName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Description2 = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    ArticleIdGeneral = table.Column<int>(nullable: true),
                    ArticleIdGeneralDescr = table.Column<string>(nullable: true),
                    ItsGeneral = table.Column<bool>(nullable: false),
                    Note = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Note2 = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    ScientificName = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    ActiveIngredients = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Dosage = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    SideEffects = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Interactions = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    Precautions = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    LimitUp = table.Column<int>(nullable: false),
                    LimitDown = table.Column<int>(nullable: false),
                    DontUseAnymore = table.Column<bool>(nullable: false),
                    Size = table.Column<string>(nullable: true),
                    Caliber = table.Column<string>(nullable: true),
                    FormatIdDescr = table.Column<string>(nullable: true),
                    IsForeign = table.Column<bool>(nullable: false),
                    ArticleCategoryId = table.Column<int>(nullable: false),
                    Barcode = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: true),
                    FormatId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articale_ArticaleCategory_ArticleCategoryId",
                        column: x => x.ArticleCategoryId,
                        principalTable: "ArticaleCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articale_Articale_ArticleIdGeneral",
                        column: x => x.ArticleIdGeneral,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articale_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articale_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articale_Formats_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Formats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    OrderState = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMasters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderMasters_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderMasters_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 747, DateTimeKind.Local).AddTicks(5894)),
                    InvoiceKind = table.Column<int>(nullable: false),
                    PaymentMethod = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    TotalPrice = table.Column<double>(nullable: false),
                    TotalItem = table.Column<double>(nullable: false),
                    Payment = table.Column<double>(nullable: false),
                    RemainingAmount = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    IsReturned = table.Column<bool>(nullable: false),
                    ReturnTo = table.Column<int>(nullable: false),
                    ReturnedTime = table.Column<DateTime>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    YearId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillMaster_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillMaster_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillMaster_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillMaster_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillMaster_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DataBaseConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VersionNumber = table.Column<string>(nullable: true),
                    AccountTaxId = table.Column<int>(nullable: false),
                    TaxValue = table.Column<double>(nullable: false),
                    ValueSellPrice = table.Column<double>(nullable: false),
                    DiscountPercentage = table.Column<double>(nullable: false),
                    DateIfNotUpdatedLocal = table.Column<int>(nullable: false),
                    DateIfNotUpdatedExternal = table.Column<int>(nullable: false),
                    DayForExpiry = table.Column<int>(nullable: false),
                    CountNumberAfterComma = table.Column<int>(nullable: false),
                    RoundToNearest = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataBaseConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataBaseConfigurations_Account_AccountTaxId",
                        column: x => x.AccountTaxId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 748, DateTimeKind.Local).AddTicks(5867)),
                    KindOperation = table.Column<int>(nullable: false),
                    RelatedDocument = table.Column<int>(nullable: false, defaultValue: 0),
                    TotalDebit = table.Column<double>(nullable: false),
                    TotalCredit = table.Column<double>(nullable: false),
                    YearId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: true),
                    BranchId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryMaster_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryMaster_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryMaster_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryMaster_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    CashAccountId = table.Column<int>(nullable: false),
                    BuyAccountId = table.Column<int>(nullable: false),
                    SellAccountId = table.Column<int>(nullable: false),
                    CustomerAccountId = table.Column<int>(nullable: false),
                    CanSellBill = table.Column<bool>(nullable: false),
                    CanBuyBill = table.Column<bool>(nullable: false),
                    CanInsertEntry = table.Column<bool>(nullable: false),
                    CanDeleteEntry = table.Column<bool>(nullable: false),
                    CanDeleteBill = table.Column<bool>(nullable: false),
                    UserDesktopUI = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Account_BuyAccountId",
                        column: x => x.BuyAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Account_CashAccountId",
                        column: x => x.CashAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Account_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Account_SellAccountId",
                        column: x => x.SellAccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermissions_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ArticleUnits",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    UnitTypeId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    IsPrimary = table.Column<bool>(nullable: false),
                    QuantityForPrimary = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleUnits", x => new { x.ArticleId, x.UnitTypeId });
                    table.ForeignKey(
                        name: "FK_ArticleUnits_Articale_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleUnits_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleUnits_UnitType_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Barcode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 752, DateTimeKind.Local).AddTicks(5762)),
                    Code = table.Column<string>(nullable: true, defaultValueSql: "('')"),
                    ArticaleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barcode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Barcode_Articale_ArticaleId",
                        column: x => x.ArticaleId,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Barcode_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceTagMaster",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 749, DateTimeKind.Local).AddTicks(5840)),
                    ArticleId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    CountSoldItem = table.Column<int>(nullable: false),
                    CountGiftItem = table.Column<int>(nullable: false),
                    CountAllItem = table.Column<int>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    PharmacyOperator1 = table.Column<string>(nullable: true),
                    PharmacyOperator2 = table.Column<string>(nullable: true),
                    YearId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTagMaster", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTagMaster_Articale_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTagMaster_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTagMaster_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTagMaster_UnitType_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTagMaster_Year_YearId",
                        column: x => x.YearId,
                        principalTable: "Year",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    OrderMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Articale_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OrderMasters_OrderMasterId",
                        column: x => x.OrderMasterId,
                        principalTable: "OrderMasters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntryDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 749, DateTimeKind.Local).AddTicks(5840)),
                    KindOperation = table.Column<int>(nullable: false),
                    Debit = table.Column<double>(nullable: false),
                    Credit = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EntryMasterId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntryDetail_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryDetail_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntryDetail_EntryMaster_EntryMasterId",
                        column: x => x.EntryMasterId,
                        principalTable: "EntryMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BillDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 748, DateTimeKind.Local).AddTicks(5867)),
                    Barcode = table.Column<string>(nullable: true),
                    InvoiceKind = table.Column<int>(nullable: false),
                    UnitTypeIdBasic = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    QuantityGift = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    TotalPrice = table.Column<double>(nullable: false),
                    PriceTagId = table.Column<int>(nullable: false),
                    ArticaleId = table.Column<int>(nullable: false),
                    UnitTypeId = table.Column<int>(nullable: false),
                    BillMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetail_Articale_ArticaleId",
                        column: x => x.ArticaleId,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_BillMaster_BillMasterId",
                        column: x => x.BillMasterId,
                        principalTable: "BillMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_PriceTagMaster_PriceTagId",
                        column: x => x.PriceTagId,
                        principalTable: "PriceTagMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BillDetail_UnitType_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    BranchId = table.Column<int>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    PriceTagId = table.Column<int>(nullable: false),
                    UnitTypeId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => new { x.ArticleId, x.UnitTypeId, x.BranchId, x.StoreId, x.PriceTagId });
                    table.ForeignKey(
                        name: "FK_Inventories_Articale_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Branch_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_PriceTagMaster_PriceTagId",
                        column: x => x.PriceTagId,
                        principalTable: "PriceTagMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inventories_UnitType_UnitTypeId",
                        column: x => x.UnitTypeId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PriceTagDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationBy = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2021, 9, 16, 17, 23, 18, 750, DateTimeKind.Local).AddTicks(5814)),
                    PriceTagId = table.Column<int>(nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    SellPrice = table.Column<double>(nullable: false, defaultValue: 0.0),
                    BuyPrice = table.Column<double>(nullable: false, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceTagDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceTagDetail_User_CreationBy",
                        column: x => x.CreationBy,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTagDetail_PriceTagMaster_PriceTagId",
                        column: x => x.PriceTagId,
                        principalTable: "PriceTagMaster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceTagDetail_UnitType_UnitId",
                        column: x => x.UnitId,
                        principalTable: "UnitType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountBaseCategorys",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "حسابات عامة" },
                    { 2, "زبائن" },
                    { 3, "صناديق" },
                    { 4, "مبيعات" },
                    { 5, "مشتريات" },
                    { 6, "موردين" },
                    { 7, "تأمينات" },
                    { 8, "مصاريف" },
                    { 9, "ضرائب" },
                    { 10, "الأرباح ورأس المال" },
                    { 11, "الموجودات" }
                });

            migrationBuilder.InsertData(
                table: "Branch",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "الفرع الرئيسي" },
                    { 1, "جميع الفروع" }
                });

            migrationBuilder.InsertData(
                table: "Formats",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 141, "XR-cap" },
                    { 142, "PR-tab" },
                    { 143, "puff" },
                    { 144, "solu/glass" },
                    { 145, "solu/plastic" },
                    { 146, "susp/gls" },
                    { 147, "ear+eye+nasal-drop" },
                    { 148, "ear+eye+nasal-oint" },
                    { 149, "oral-drop glass-bottle" },
                    { 150, "oral-drop plasrtic-bottle" },
                    { 151, "eye-wash" },
                    { 158, "tab in glass-bottle" },
                    { 153, "eye-gel" },
                    { 154, "eye+nose-drop" },
                    { 155, "oral-drop in glass" },
                    { 156, "oral-drop in plastic" },
                    { 157, "tab-sachet" },
                    { 140, "coated-tab in bottle" },
                    { 159, "dental-paste" },
                    { 160, "coated-tab in glass-bottle" },
                    { 161, "solu+spray" },
                    { 162, "coated-tab glass-bottle" },
                    { 163, "paste" },
                    { 152, "nasal-wash" },
                    { 139, "tab in bottle" },
                    { 132, "mouth-gel" },
                    { 137, "coated-tab/sachet" },
                    { 113, "plstic-amp" },
                    { 114, "powder-sachet" },
                    { 115, "powder-spray" },
                    { 116, "vial+2W.F.I." },
                    { 117, "vial+1W.F.I. 5ml" },
                    { 118, "vial+2W.F.I. 2ml" },
                    { 119, "oral-drops" },
                    { 120, "ear+nasal-drop" },
                    { 121, "eye+ear-drop" },
                    { 122, "vial-plastic" },
                    { 123, "gelatin-cap" },
                    { 138, "tab/sachet" },
                    { 124, "cap in plastic-bottle" },
                    { 126, "cap/sachet" },
                    { 127, "emul-gel" },
                    { 128, "tab-plister" },
                    { 129, "rect-oint" },
                    { 130, "tab in plastic-bottle" },
                    { 131, "liquied-soap" },
                    { 164, "eye&ear-drop" },
                    { 133, "coated-tab plister" },
                    { 134, "oint in glass-bottle" },
                    { 135, "oint in plastic-bottle" },
                    { 136, "cap in bottle" },
                    { 125, "cap in blister" },
                    { 165, "cream-beige" },
                    { 172, "oral-drop glass-dropper" },
                    { 167, "eye-solu" },
                    { 196, "trans-solu" },
                    { 197, "oral-spray" },
                    { 198, "lip-stick" },
                    { 199, "rectal-solu" },
                    { 200, "derm-solu" },
                    { 201, "sol + محقن" },
                    { 202, "gel + applicator" },
                    { 203, "foam-solu" },
                    { 204, "nasal spray" },
                    { 205, "solu+محقن" },
                    { 206, "ER-cap" },
                    { 195, "milk" },
                    { 207, "plastic-vial+urocap+2 way" },
                    { 209, "dry-syrup in-gls" },
                    { 210, "dry-syrup in-pls" },
                    { 211, "eye-susp" },
                    { 212, "alcool-sol" },
                    { 213, "water-sol" },
                    { 214, "loz-diet" },
                    { 215, "puff-nasal-spray" },
                    { 216, "vag-cream+applic" },
                    { 217, "oral-granules" },
                    { 218, "vial-W.F.I." },
                    { 219, "vial + W.F.I." },
                    { 208, "plastic-vial+urocap" },
                    { 166, "cream-rose" },
                    { 194, "dressing" },
                    { 192, "dose-spray" },
                    { 168, "dispers-tab" },
                    { 169, "oval-tab" },
                    { 170, "glycerol-gel" },
                    { 171, "vag-oint" },
                    { 112, "coated-tab in Alu" },
                    { 173, "oral-drop plastic-dropper" },
                    { 174, "cartoon" },
                    { 175, "oral-solu" },
                    { 176, "cream in plastic-tube" },
                    { 177, "one-dose-vial" },
                    { 178, "vag-efferv-tab" },
                    { 193, "hand-gel" },
                    { 179, "serum in p.v.c. bag+port+butterflycap" },
                    { 181, "serum in p-p-bag+port+vialCap" },
                    { 182, "serum+port+butterflyCap" },
                    { 183, "serum+port+butterflyCap+aluBag" },
                    { 184, "serum+port+vialCap" },
                    { 185, "plastic-bag" },
                    { 186, "CR-tab" },
                    { 187, "MR-cap" },
                    { 188, "sunLing-tab" },
                    { 189, "hand-wash" },
                    { 190, "oil" },
                    { 191, "cream + applicator" },
                    { 180, "serum in p.v.c. bag+port+vialcap" },
                    { 111, "coated-tab in plstic-bottle" },
                    { 105, "syrup single-dose" },
                    { 109, "coated-tab alum-strip" },
                    { 29, "caplet in plastic-cont" },
                    { 30, "gum" },
                    { 31, "dispersable-tab" },
                    { 32, "SR-coated-tab" },
                    { 33, "SR-cap" },
                    { 34, "vag-solu" },
                    { 35, "chew-tab" },
                    { 36, "ovule" },
                    { 37, "vag-ovule" },
                    { 38, "vag-cream" },
                    { 39, "nail-solu" },
                    { 40, "oral-paste" },
                    { 41, "ear-drop" },
                    { 42, "amp" },
                    { 43, "vial" },
                    { 44, "eye-oint" },
                    { 45, "rectal-cream" },
                    { 46, "dry-vial" },
                    { 47, "emultion" },
                    { 48, "enema" },
                    { 49, "vag-douch" },
                    { 50, "XR-tab" },
                    { 51, "vag-tab" },
                    { 28, "caplet" },
                    { 27, "inh-cap" },
                    { 26, "dose nasal-spray" },
                    { 25, "sachet" },
                    { 1, "كل الأشكال الدوائية" },
                    { 2, "cap" },
                    { 3, "coated-tab" },
                    { 4, "supp" },
                    { 5, "syrup" },
                    { 6, "cream" },
                    { 7, "tab" },
                    { 8, "susp" },
                    { 9, "effervi-tab" },
                    { 10, "oint" },
                    { 11, "gel" },
                    { 52, "elexir" },
                    { 12, "solu" },
                    { 14, "SR-tab" },
                    { 15, "gargle" },
                    { 16, "nasal-spray" },
                    { 17, "coated-tab plastic-bottle" },
                    { 18, "nasal-gel" },
                    { 19, "cap for inhal" },
                    { 20, "oral-drop" },
                    { 21, "dry-syrup" },
                    { 22, "MR-tab" },
                    { 23, "oral-gel" },
                    { 24, "DR-cap" },
                    { 13, "oral-vial" },
                    { 53, "vag-douch + app" },
                    { 54, "lotion" },
                    { 55, "mouth-wash" },
                    { 85, "dental-gel" },
                    { 86, "vag-gel" },
                    { 87, "XR-coated-tab" },
                    { 88, "serum+urocap" },
                    { 89, "serum+urocap+2way" },
                    { 90, "vag soft-gel-cap" },
                    { 91, "plastic-amp eye-drop" },
                    { 92, "dry-susp" },
                    { 93, "ER-tab" },
                    { 94, "serum" },
                    { 95, "bi-tab" },
                    { 84, "vial+lido" },
                    { 96, "soft-gel-cap" },
                    { 98, "bottle" },
                    { 99, "bag" },
                    { 100, "plastic-amp" },
                    { 101, "plastic-vial" },
                    { 102, "syrup in plastic-dose" },
                    { 103, "tooth-paste" },
                    { 104, "surup" },
                    { 220, "rectal-douch" },
                    { 106, "plastic single-dose" },
                    { 107, "foam" },
                    { 108, "disinteg-tab" },
                    { 97, "coated-tab in plastic-bottle" },
                    { 110, "pre-filled syringe" },
                    { 83, "soft-cap" },
                    { 81, "aplicapeye-oint" },
                    { 56, "cartridge" },
                    { 57, "coated-tab+loz" },
                    { 58, "loz" },
                    { 59, "dental-cartridge" },
                    { 60, "gum-tab" },
                    { 61, "plast-oral-drop" },
                    { 62, "chew-gum" },
                    { 63, "powder" },
                    { 64, "سوار للمعصم" },
                    { 65, "salt" },
                    { 66, "shampoo" },
                    { 82, "gel-cap" },
                    { 67, "rectal-oint" },
                    { 69, "sublingual-tab" },
                    { 70, "soap" },
                    { 71, "balsam" },
                    { 72, "spray" },
                    { 74, "aerosol-spray" },
                    { 75, "DR-tab" },
                    { 76, "vial+amp+lido" },
                    { 77, "vial+W.F.I." },
                    { 78, "vial+water-amp" },
                    { 79, "vial+amp" },
                    { 80, "eye-drop" },
                    { 68, "nasal-drop" },
                    { 221, "dental+dermal-spray" }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "BranchId", "Name" },
                values: new object[] { 1, 2, "جميع المستودعات" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "BranchId", "Name" },
                values: new object[] { 2, 2, "المستودع الأول" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "BranchId", "Freez", "Name", "Password", "Position", "StoreId" },
                values: new object[,]
                {
                    { 1, 1, false, "All User", "allUser", 0, 1 },
                    { 2, 2, false, "admin", "admin", 0, 2 },
                    { 3, 2, false, "manager", "manager", 1, 2 },
                    { 4, 2, false, "dataEntry", "dataEntry", 2, 2 },
                    { 5, 2, false, "reportReader", "reportReader", 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountCategoryId", "AccountGeneralId", "AccountState", "CategoryId", "CreationBy", "CreationDate", "General", "Name" },
                values: new object[] { 1, null, null, 2, 1, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "الحساب العام" });

            migrationBuilder.InsertData(
                table: "ArticaleCategory",
                columns: new[] { "Id", "CreationBy", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "أدوية" },
                    { 2, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "اكسسوارات" }
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "CreationBy", "CreationDate", "Location", "Name" },
                values: new object[,]
                {
                    { 60, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "غولدن ميد فارما ( الذهبية ) " },
                    { 59, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "عبد الوهّاب القنواتي" },
                    { 58, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "شفا" },
                    { 57, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "شرق المتوسط(ليم) " },
                    { 56, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "شرق المتوسط(ليم)" },
                    { 55, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "سيفارما" },
                    { 54, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "سيردا فارما" },
                    { 53, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "سيتي فارما" },
                    { 51, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "سرّاج" },
                    { 61, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "فارماسير" },
                    { 50, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "زين فارما" },
                    { 49, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "رشا" },
                    { 48, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "راما فارما " },
                    { 47, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "راما فارما" },
                    { 46, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "دياموند" },
                    { 45, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "دومنا" },
                    { 44, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "دلتا" },
                    { 52, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "سلامة كير" },
                    { 62, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "فكتوريا" },
                    { 63, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "فيتا" },
                    { 64, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "كسبار و شعباني" },
                    { 81, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "يونيفارما" },
                    { 80, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "يونيشيما" },
                    { 79, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "يونايتد" },
                    { 78, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "هيومن" },
                    { 77, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ميغا فارما" },
                    { 76, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ميرسي فارما" },
                    { 75, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ميديوتيك" },
                    { 74, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ميديكو" },
                    { 73, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ميديفارم" },
                    { 72, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "مياميد" },
                    { 71, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "معتوق فارما" },
                    { 70, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "مسعود للمحاليل الطبية" },
                    { 69, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "مسعود فارما" },
                    { 68, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ماجيكو" },
                    { 67, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "لاما فارما" },
                    { 66, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "كيمي" },
                    { 65, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "كندة فارما" },
                    { 42, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "حماة فارما" },
                    { 41, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ترياق" },
                    { 43, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "حياة فارما" },
                    { 39, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "برولاين" },
                    { 40, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "بيوميد" },
                    { 16, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الشهباء" },
                    { 15, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "السلام" },
                    { 14, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "السعد" },
                    { 13, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الرائد" },
                    { 12, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الرازي" },
                    { 11, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الدولية" },
                    { 10, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "التراميديكا" },
                    { 9, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "البلسم" },
                    { 8, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الأفق" },
                    { 7, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "افاميا" },
                    { 6, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ابن سينا" },
                    { 5, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ابن زهر" },
                    { 4, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ابن رشد" },
                    { 3, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ابن حيان" },
                    { 2, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "ابن الهيثم" },
                    { 1, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "كل الشركات الدوائية" },
                    { 18, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الفارس" },
                    { 19, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "القنواتي" },
                    { 17, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الفا" },
                    { 21, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الما" },
                    { 38, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "بركات " },
                    { 37, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "بركات" },
                    { 36, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "بحري" },
                    { 35, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "آسكو فارما" },
                    { 34, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "أوغاريت" },
                    { 20, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "القنواتي " },
                    { 32, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "أوبري" },
                    { 31, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "أسيا" },
                    { 33, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "أوشر" },
                    { 29, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "إميسا" },
                    { 28, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "اليوسف" },
                    { 27, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الوطنية" },
                    { 26, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الهلال" },
                    { 25, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "النورس" },
                    { 24, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "المتوسط" },
                    { 23, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "المتحدة " },
                    { 22, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "الما " },
                    { 30, 2, new DateTime(2021, 9, 16, 17, 23, 18, 761, DateTimeKind.Local).AddTicks(5519), "Damascus", "أدامكو" }
                });

            migrationBuilder.InsertData(
                table: "UnitType",
                columns: new[] { "Id", "CreationBy", "CreationDate", "Name" },
                values: new object[,]
                {
                    { 6, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "إبرة" },
                    { 1, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "لا يوجد" },
                    { 2, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "طرد" },
                    { 3, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "علبة" },
                    { 4, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "ظرف" },
                    { 5, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "حبة" }
                });

            migrationBuilder.InsertData(
                table: "Year",
                columns: new[] { "Id", "CreationBy", "CreationDate", "Name" },
                values: new object[] { 1, 2, new DateTime(2021, 9, 16, 17, 23, 18, 754, DateTimeKind.Local).AddTicks(5707), "2021" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountCategoryId", "AccountGeneralId", "AccountState", "CategoryId", "CreationBy", "CreationDate", "General", "Name" },
                values: new object[,]
                {
                    { 2, null, 1, 2, 2, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "الزبائن" },
                    { 3, null, 1, 2, 3, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "الصناديق" },
                    { 4, null, 1, 2, 4, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "المبيعات" },
                    { 5, null, 1, 2, 5, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "المشتريات" },
                    { 6, null, 1, 2, 6, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "المندوبين" },
                    { 7, null, 1, 2, 9, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "الضرائب" },
                    { 8, null, 1, 2, 8, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "المصاريف" },
                    { 9, null, 1, 2, 10, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "رأس المال" },
                    { 10, null, 1, 2, 11, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), true, "الموجودات" }
                });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "AccountCategoryId", "AccountGeneralId", "AccountState", "CategoryId", "CreationBy", "CreationDate", "General", "Name" },
                values: new object[,]
                {
                    { 11, null, 2, 2, 2, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "زبائن الصيدلية" },
                    { 12, null, 3, 2, 3, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "صندوق الصيدلية" },
                    { 13, null, 4, 2, 4, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "مبيعات الصيدلية" },
                    { 14, null, 5, 2, 5, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "مشتريات الصيدلية" },
                    { 16, null, 6, 2, 6, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "مندوب شركة أفاميا" },
                    { 17, null, 6, 2, 6, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "مندوب شركة ألفا" },
                    { 15, null, 7, 2, 9, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "ضريبة الصيدلية" },
                    { 18, null, 8, 2, 8, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "مصروف الصيدلية" },
                    { 19, null, 9, 2, 10, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "رأس مال الصيدلية" },
                    { 20, null, 10, 2, 11, 2, new DateTime(2021, 9, 16, 17, 23, 18, 762, DateTimeKind.Local).AddTicks(5493), false, "بضاعة أول مدة" }
                });

            migrationBuilder.InsertData(
                table: "DataBaseConfigurations",
                columns: new[] { "Id", "AccountTaxId", "CountNumberAfterComma", "DateIfNotUpdatedExternal", "DateIfNotUpdatedLocal", "DayForExpiry", "DiscountPercentage", "RoundToNearest", "TaxValue", "ValueSellPrice", "VersionNumber" },
                values: new object[] { 1, 12, 0, 10, 30, 60, 0.029999999999999999, 0, 0.0030000000000000001, 0.20000000000000001, "B11" });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "BuyAccountId", "CanBuyBill", "CanDeleteBill", "CanDeleteEntry", "CanInsertEntry", "CanSellBill", "CashAccountId", "CustomerAccountId", "SellAccountId", "UserDesktopUI", "UserId" },
                values: new object[,]
                {
                    { 2, 14, true, true, true, true, true, 12, 11, 13, 1, 2 },
                    { 3, 14, false, false, false, false, false, 12, 11, 13, 1, 3 },
                    { 4, 14, false, false, false, false, false, 12, 11, 13, 1, 4 },
                    { 5, 14, false, false, false, false, false, 12, 11, 13, 1, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountCategoryId",
                table: "Account",
                column: "AccountCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountGeneralId",
                table: "Account",
                column: "AccountGeneralId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CategoryId",
                table: "Account",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CreationBy",
                table: "Account",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategory_AccountBaseCategoryId",
                table: "AccountCategory",
                column: "AccountBaseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountCategory_CreationBy",
                table: "AccountCategory",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_Articale_ArticleCategoryId",
                table: "Articale",
                column: "ArticleCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articale_ArticleIdGeneral",
                table: "Articale",
                column: "ArticleIdGeneral");

            migrationBuilder.CreateIndex(
                name: "IX_Articale_CompanyId",
                table: "Articale",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Articale_CreationBy",
                table: "Articale",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_Articale_FormatId",
                table: "Articale",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticaleCategory_CreationBy",
                table: "ArticaleCategory",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUnits_CreationBy",
                table: "ArticleUnits",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUnits_UnitTypeId",
                table: "ArticleUnits",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_ArticaleId",
                table: "Barcode",
                column: "ArticaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Barcode_CreationBy",
                table: "Barcode",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_ArticaleId",
                table: "BillDetail",
                column: "ArticaleId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_BillMasterId",
                table: "BillDetail",
                column: "BillMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_CreationBy",
                table: "BillDetail",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_PriceTagId",
                table: "BillDetail",
                column: "PriceTagId");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetail_UnitTypeId",
                table: "BillDetail",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BillMaster_AccountId",
                table: "BillMaster",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_BillMaster_BranchId",
                table: "BillMaster",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BillMaster_CreationBy",
                table: "BillMaster",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_BillMaster_StoreId",
                table: "BillMaster",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_BillMaster_YearId",
                table: "BillMaster",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Company_CreationBy",
                table: "Company",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_Connection_UserId",
                table: "Connection",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DataBaseConfigurations_AccountTaxId",
                table: "DataBaseConfigurations",
                column: "AccountTaxId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDetail_AccountId",
                table: "EntryDetail",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDetail_CreationBy",
                table: "EntryDetail",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_EntryDetail_EntryMasterId",
                table: "EntryDetail",
                column: "EntryMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryMaster_AccountId",
                table: "EntryMaster",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryMaster_BranchId",
                table: "EntryMaster",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EntryMaster_CreationBy",
                table: "EntryMaster",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_EntryMaster_YearId",
                table: "EntryMaster",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_BranchId",
                table: "Inventories",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_PriceTagId",
                table: "Inventories",
                column: "PriceTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_StoreId",
                table: "Inventories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_UnitTypeId",
                table: "Inventories",
                column: "UnitTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ArticleId",
                table: "OrderDetails",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_CreationBy",
                table: "OrderDetails",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderMasterId",
                table: "OrderDetails",
                column: "OrderMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CompanyId",
                table: "OrderMasters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderMasters_CreationBy",
                table: "OrderMasters",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagDetail_CreationBy",
                table: "PriceTagDetail",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagDetail_PriceTagId",
                table: "PriceTagDetail",
                column: "PriceTagId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagDetail_UnitId",
                table: "PriceTagDetail",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagMaster_ArticleId",
                table: "PriceTagMaster",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagMaster_BranchId",
                table: "PriceTagMaster",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagMaster_CreationBy",
                table: "PriceTagMaster",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagMaster_UnitId",
                table: "PriceTagMaster",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceTagMaster_YearId",
                table: "PriceTagMaster",
                column: "YearId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_BranchId",
                table: "Stores",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitType_CreationBy",
                table: "UnitType",
                column: "CreationBy");

            migrationBuilder.CreateIndex(
                name: "IX_User_BranchId",
                table: "User",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StoreId",
                table: "User",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_BuyAccountId",
                table: "UserPermissions",
                column: "BuyAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_CashAccountId",
                table: "UserPermissions",
                column: "CashAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_CustomerAccountId",
                table: "UserPermissions",
                column: "CustomerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_SellAccountId",
                table: "UserPermissions",
                column: "SellAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Year_CreationBy",
                table: "Year",
                column: "CreationBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleUnits");

            migrationBuilder.DropTable(
                name: "Barcode");

            migrationBuilder.DropTable(
                name: "BillDetail");

            migrationBuilder.DropTable(
                name: "Connection");

            migrationBuilder.DropTable(
                name: "DataBaseConfigurations");

            migrationBuilder.DropTable(
                name: "EntryDetail");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "PriceTagDetail");

            migrationBuilder.DropTable(
                name: "SettingNotifications");

            migrationBuilder.DropTable(
                name: "UserNotifications");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "BillMaster");

            migrationBuilder.DropTable(
                name: "EntryMaster");

            migrationBuilder.DropTable(
                name: "OrderMasters");

            migrationBuilder.DropTable(
                name: "PriceTagMaster");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Articale");

            migrationBuilder.DropTable(
                name: "UnitType");

            migrationBuilder.DropTable(
                name: "Year");

            migrationBuilder.DropTable(
                name: "AccountCategory");

            migrationBuilder.DropTable(
                name: "ArticaleCategory");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Formats");

            migrationBuilder.DropTable(
                name: "AccountBaseCategorys");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Branch");
        }
    }
}
