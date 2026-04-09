# E-Commerce Clothes (ASP.NET MVC 5)

## 1) Project Summary
This project is a full-stack e-commerce web application for selling clothes, built with **ASP.NET MVC 5** and **Entity Framework 6** on **.NET Framework 4.8.1**.

It includes:
- A **customer-facing storefront** (browse, search, cart, checkout)
- An **admin area** (authentication, user management, advertisement listing, revenue analytics)
- A **SQL Server-backed data layer** with DAO pattern and entity mapping

## 2) What I Delivered (Senior-Level Scope)
I designed and implemented the application across key software layers:

- **Architecture & Layering**
  - Split solution into 3 projects:
    - `QLBH_64132763`: Web/UI layer (MVC controllers, views, routes)
    - `model_64132763`: Data access + EF entities + business queries
    - `Common`: Shared utilities (email helper, string normalization)

- **Core Business Features**
  - Product listing by category with pagination
  - Product detail and keyword search (including JSON autocomplete endpoint)
  - Session-based shopping cart (add/update/delete/clear)
  - Checkout flow creating order (`CART`) and order lines (`CART_DETAIL`)
  - Order confirmation email notification to customer/admin

- **User & Security Features**
  - User registration with duplicate username/email checks
  - Password hashing using **SHA-256** before persistence
  - Login/logout and session handling
  - Captcha validation on registration flow

- **Admin Features**
  - Admin login and base controller session guard
  - User management: list/search/create/edit/delete/change status
  - Advertisement listing with paging/search
  - Revenue-by-month aggregation API for charting/dashboard usage

- **Platform & UX Foundations**
  - Friendly route mapping for key user journeys (`/register`, `/login`, `/search`, `/Payment`, etc.)
  - Asset bundling configuration (jQuery, Bootstrap, CSS)
  - Menu and layout composition via child actions

## 3) Technical Stack
- **Backend:** ASP.NET MVC 5, C#
- **ORM/Data:** Entity Framework 6 (Database First style entities/context)
- **Database:** Microsoft SQL Server (`QLBH_64132763.sql` schema/script)
- **Frontend:** Razor Views, Bootstrap, jQuery
- **Libraries:** PagedList.Mvc, Captcha, Newtonsoft.Json

## 4) Repository Structure
```text
/home/runner/work/e-commerce-clothes/e-commerce-clothes
├── QLBH_64132763/         # MVC web app (controllers/views/routes/config)
├── model_64132763/        # EF DbContext, entities, DAO, view models
├── Common/                # Shared helpers (mail/string)
├── QLBH_64132763.sln      # Solution file
└── QLBH_64132763.sql      # Database script
```

## 5) Key Modules Implemented
- **Storefront controllers:**
  - `Home_64132763Controller`
  - `Product_64132763Controller`
  - `Cart_64132763Controller`
  - `User_64132763Controller`
- **Admin controllers (`Areas/Admin`):**
  - `Login_64132763Controller`
  - `User_64132763Controller`
  - `Advertisement_64132763Controller`
  - `Cart_64132763Controller` (revenue)
- **Data Access (DAO):**
  - `ProductDAO`, `UserDAO`, `CartDAO`, `CartDetailDAO`, `AdvertisementDAO`, etc.

## 6) How to Run Locally
### Prerequisites
- Windows machine with **Visual Studio** (ASP.NET web workload)
- **.NET Framework 4.8.1 Developer Pack**
- SQL Server (connection string configured in `QLBH_64132763/Web.config`)

### Steps
1. Open `QLBH_64132763.sln` in Visual Studio.
2. Restore NuGet packages.
3. Create database objects using `QLBH_64132763.sql` (or align with existing DB).
4. Update `connectionStrings` in `QLBH_64132763/Web.config`.
5. Configure SMTP values in `appSettings` for order email sending.
6. Build and run the `QLBH_64132763` web project.

## 7) Validation Notes
- In this Linux CI environment, `dotnet build` fails because this is a **.NET Framework MVC project** requiring Windows/Visual Studio web targets and .NET Framework reference packs.
- No dedicated automated test project is currently included in the solution.

## 8) Business/Engineering Value
This project demonstrates end-to-end ownership of:
- Multi-layer web application design
- E-commerce transaction flow implementation
- Admin operations and analytics reporting
- Secure credential handling pattern (hashing + session auth)
- Data modeling and production-style query/paging patterns

---
This repository reflects practical experience building and integrating complete web commerce functionality from database to UI with operational admin capabilities.
