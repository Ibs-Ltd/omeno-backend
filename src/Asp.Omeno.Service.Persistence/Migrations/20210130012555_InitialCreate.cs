using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Asp.Omeno.Service.Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DefaultTimes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultTimes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: false),
                    FileType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceStatuses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductStatuses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSteps",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSteps", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: false),
                    VAT = table.Column<int>(nullable: false),
                    Currency_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Countries_Currencies_Currency_ID",
                        column: x => x.Currency_ID,
                        principalTable: "Currencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Tokens = table.Column<long>(nullable: false),
                    StripeCustomer_ID = table.Column<string>(nullable: true),
                    AcceptedTerms = table.Column<bool>(nullable: false),
                    Language_ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Languages_Language_ID",
                        column: x => x.Language_ID,
                        principalTable: "Languages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    AutoNotify = table.Column<bool>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Timer = table.Column<bool>(nullable: false),
                    TimeToNotify = table.Column<DateTime>(nullable: false),
                    NotificationType_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notifications_NotificationTypes_NotificationType_ID",
                        column: x => x.NotificationType_ID,
                        principalTable: "NotificationTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Index = table.Column<int>(nullable: false),
                    Counter = table.Column<int>(nullable: false),
                    ProductType_ID = table.Column<Guid>(nullable: false),
                    ProductStatus_ID = table.Column<Guid>(nullable: false),
                    ProductStep_ID = table.Column<Guid>(nullable: false),
                    FirstImage_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Images_FirstImage_ID",
                        column: x => x.FirstImage_ID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductStatuses_ProductStatus_ID",
                        column: x => x.ProductStatus_ID,
                        principalTable: "ProductStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductSteps_ProductStep_ID",
                        column: x => x.ProductStep_ID,
                        principalTable: "ProductSteps",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductType_ID",
                        column: x => x.ProductType_ID,
                        principalTable: "ProductTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    Country_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_Country_ID",
                        column: x => x.Country_ID,
                        principalTable: "Countries",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CardNumber = table.Column<string>(nullable: false),
                    CardHolder = table.Column<string>(nullable: false),
                    Month = table.Column<string>(nullable: false),
                    Year = table.Column<string>(nullable: false),
                    User_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NotificationUsers",
                columns: table => new
                {
                    Notification_ID = table.Column<Guid>(nullable: false),
                    User_ID = table.Column<Guid>(nullable: false),
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationUsers", x => new { x.Notification_ID, x.User_ID });
                    table.ForeignKey(
                        name: "FK_NotificationUsers_Notifications_Notification_ID",
                        column: x => x.Notification_ID,
                        principalTable: "Notifications",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationUsers_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoBids",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    Product_ID = table.Column<Guid>(nullable: false),
                    User_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoBids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AutoBids_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoBids_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    TimeOfBid = table.Column<DateTime>(nullable: false),
                    IsLast = table.Column<bool>(nullable: false),
                    IsAutoBid = table.Column<bool>(nullable: false),
                    Product_ID = table.Column<Guid>(nullable: false),
                    User_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Bids_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiveawayMembers",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Member = table.Column<string>(nullable: true),
                    Product_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiveawayMembers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GiveawayMembers_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    InvoiceStatus_ID = table.Column<Guid>(nullable: false),
                    InvoiceType_ID = table.Column<Guid>(nullable: false),
                    Product_ID = table.Column<Guid>(nullable: true),
                    User_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceStatuses_InvoiceStatus_ID",
                        column: x => x.InvoiceStatus_ID,
                        principalTable: "InvoiceStatuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_InvoiceTypes_InvoiceType_ID",
                        column: x => x.InvoiceType_ID,
                        principalTable: "InvoiceTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Product_ID = table.Column<Guid>(nullable: false),
                    Image_ID = table.Column<Guid>(nullable: false),
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => new { x.Product_ID, x.Image_ID });
                    table.ForeignKey(
                        name: "FK_ProductImages_Images_Image_ID",
                        column: x => x.Image_ID,
                        principalTable: "Images",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    AddressName = table.Column<string>(nullable: false),
                    AddressNameTwo = table.Column<string>(nullable: true),
                    CityName = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    User_ID = table.Column<Guid>(nullable: false),
                    City_ID = table.Column<Guid>(nullable: true),
                    AddressType_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Addresses_AddressTypes_AddressType_ID",
                        column: x => x.AddressType_ID,
                        principalTable: "AddressTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Cities_City_ID",
                        column: x => x.City_ID,
                        principalTable: "Cities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AddressType_ID",
                table: "Addresses",
                column: "AddressType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_City_ID",
                table: "Addresses",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_User_ID",
                table: "Addresses",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoBids_Product_ID",
                table: "AutoBids",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_AutoBids_User_ID",
                table: "AutoBids",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_Product_ID",
                table: "Bids",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_User_ID",
                table: "Bids",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Country_ID",
                table: "Cities",
                column: "Country_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Currency_ID",
                table: "Countries",
                column: "Currency_ID");

            migrationBuilder.CreateIndex(
                name: "IX_GiveawayMembers_Product_ID",
                table: "GiveawayMembers",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceStatus_ID",
                table: "Invoices",
                column: "InvoiceStatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceType_ID",
                table: "Invoices",
                column: "InvoiceType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_Product_ID",
                table: "Invoices",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_User_ID",
                table: "Invoices",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_NotificationType_ID",
                table: "Notifications",
                column: "NotificationType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationUsers_User_ID",
                table: "NotificationUsers",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_User_ID",
                table: "Payments",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_Image_ID",
                table: "ProductImages",
                column: "Image_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_FirstImage_ID",
                table: "Products",
                column: "FirstImage_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatus_ID",
                table: "Products",
                column: "ProductStatus_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStep_ID",
                table: "Products",
                column: "ProductStep_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductType_ID",
                table: "Products",
                column: "ProductType_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Language_ID",
                table: "Users",
                column: "Language_ID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AutoBids");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "DefaultTimes");

            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.DropTable(
                name: "GiveawayMembers");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "NotificationUsers");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "AddressTypes");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "InvoiceStatuses");

            migrationBuilder.DropTable(
                name: "InvoiceTypes");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "NotificationTypes");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "ProductStatuses");

            migrationBuilder.DropTable(
                name: "ProductSteps");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
