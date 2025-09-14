# Manzili

**Manzili** is a web platform designed to empower home-based service providers by connecting them with customers, simplifying marketing, and fostering community collaboration. Built with **ASP.NET Core 8 MVC**, Manzili provides a centralized, user-friendly space to showcase services, book appointments, and manage deliveries.

---

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [Database Design](#database-design)
- [Contact](#contact)

---

## Overview
Home-based service providers often struggle to market their services effectively and reach a wider audience. Buyers face difficulty discovering reliable local services. Manzili bridges this gap by offering:

- Easy service listing and promotion
- Service booking and delivery integration
- Collaboration opportunities between providers
- Community support and engagement

---

## Features
- **Service Management**: Add, edit, and remove services with details.
- **Booking System**: Customers can request and schedule services.
- **Delivery Integration**: Connect with delivery services to fulfill orders.
- **Collaboration Tools**: Providers can collaborate on projects.
- **Guides & Resources**: Tutorials for managing online services.
- **Feedback & Reviews**: Collect customer feedback to improve services.
- **Notifications**: Stay up-to-date with order and system alerts.
- **Discounts & Promotions**: Apply and track discount usage.
- **Payments**: Integrated order payment system with transaction logging.
- **Data Integrity**:  
  - Orders & Payments are **never deleted** (kept for financial records).  
  - Buyer or User deletions result in **“Deleted Buyer/User”** markers instead of removing history.  
  - OrderService stores **snapshots** (price & title) to preserve historical accuracy even if a Service is deleted.  

---

## Technologies Used
- **Backend**: ASP.NET Core 8 MVC
- **Frontend**: Razor Views, HTML5, CSS3, Bootstrap
- **Database**: SQL Server / EF Core
- **Version Control**: Git & GitHub
- **Hosting (Optional)**: IIS / Azure

---

## Installation

1. Clone the repository:

```bash
git clone git@github.com:nourelden385sewedy/Manzili.git
```

2. Navigate to the project folder:
```bash
cd Manzili
```

3. Update your appsettings.json with your SQL Server connection string

4. Update the database:
```bash
dotnet ef database update
```

5. Run the application:
```bash
dotnet run
```

---

## Usage

- Register as a Provider or Buyer.
- Providers can list services, create discounts, and manage orders.
- Buyers can browse services, place orders, apply discounts, and make payments.
- Admins can oversee users, services, and platform activity.

---

## Database Design

The full database schema, including entities, relationships, constraints, and deletion/nulling policies, is documented here: 👉 [Database Schema & Relationships](docs)

---

## Contact

**Author:** Nour El-den El Mohamed
- **Github:** [Nour El-den Github](https://github.com/nourelden385sewedy)
- **Email:** [Nour El-den Email](noureldenmohamed124@gmail.com)


