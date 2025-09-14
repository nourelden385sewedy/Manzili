# Manzili – Database Schema & Relationships

## 1. Introduction
This document describes the database structure and entity relationships for the **Manzili** platform — a service marketplace where buyers can order services from providers.  
It covers entities, relationships, constraints, indexes, and deletion policies based on business rules.

**Technologies Used:**
- ASP.NET Core 8
- Entity Framework Core 8
- SQL Server

---

## 2. Entity List & Tables Overview
- **User** → Stores buyers, providers, and admins.  
- **Service** → Represents a service provided by a provider.  
- **ServiceImage** → Stores images related to a service.  
- **Order** → Represents a purchase request by a buyer.  
- **OrderService** → Connects orders to services, supports multiple services per order.  
- **Discount** → Stores discount codes applied to services.  
- **DiscountUsage** → Logs discount usage by users.  
- **Payment** → Stores payment information for orders.  
- **Notification** → Stores user-specific messages.  
- **Address** → Stores buyer addresses.  
- **Review** → Buyer reviews for services.  

---

## 3. Entity Details & Deletion Policies

### User
**Fields**
- `Id` (PK, int)  
- `FullName` (nvarchar(100), required)  
- `Email` (nvarchar(100), required, unique)  
- `PhoneNumber` (nvarchar(15), optional)  
- `PasswordHash` (nvarchar(256), required)  
- `Role` (enum: Buyer, Provider, Admin, stored as string)  
- `CreatedAt`, `UpdatedAt`  

**Relationships**
- 1 → * Services (as Provider)  
- 1 → * Orders (as Buyer)  
- 1 → * Reviews  
- 1 → * Notifications  
- 1 → * Addresses  
- 1 → * Payments (as Buyer)  

**Delete Behavior**
- Cascade delete → Services, Reviews, Notifications, Addresses  
- Services deletion cascades to ServiceImages and Discounts  
- Orders remain (BuyerId set to NULL → backend shows “Deleted Buyer”)  
- DiscountUsage remains (UserId set to NULL → backend shows “Deleted User”)  
- Payments always retained  

---

### Service
**Fields**
- `Id` (PK, int)  
- `Title`, `Description`, `Category`  
- `Price`, `Status`, `IsAvailable`  
- `OrdersCount`, `Revenue`, `ViewsCount`  
- `IsFeatured`, `IsRecommended`  
- `ProviderId` (FK → User)  
- `CreatedAt`, `UpdatedAt`  

**Relationships**
- 1 → * Images  
- 1 → * OrderServices  
- 1 → * Reviews  
- 1 → * Discounts  

**Delete Behavior**
- Cascade delete → ServiceImages, Discounts, Reviews  
- OrderServices remain (ServiceId set to NULL, keep snapshot fields: `PriceAtOrder`, `ServiceTitleAtOrder` + backend shows “Deleted Service”)  
- Payments remain  

---

### Order
**Fields**
- `Id` (PK, int)  
- `SubTotal`, `DiscountAmount`, `DeliveryFee`, `TotalAmount`  
- `IsConfirmed` (bit)  
- `Status` (enum: Pending, Confirmed, Completed, Cancelled)  
- `BuyerId` (FK → User, nullable)  
- `CreatedAt`, `UpdatedAt`  

**Relationships**
- 1 → 1 Payment  
- 1 → * OrderServices  

**Delete Behavior**
- Orders are **never deleted** (kept for financial/history reasons)  
- Buyer deletion → BuyerId set to NULL, backend shows “Deleted Buyer”  
- Cascade delete → OrderServices if Order itself is deleted manually  
- Payment always retained  

---

### OrderService
**Fields**
- `Id` (PK, int)  
- `Quantity`  
- `CustomizationDetails`  
- `PriceAtOrder` (decimal snapshot)  
- `ServiceTitleAtOrder` (string snapshot)  
- `OrderId` (FK → Order)  
- `ServiceId` (FK → Service, nullable if deleted)  
- `ProviderId` (FK → User)  
- `CreatedAt`, `UpdatedAt`  

**Delete Behavior**
- Cascade delete if Order is deleted  
- Service deletion → ServiceId set to NULL (snapshots preserved)  

---

### Discount
**Fields**
- `Id` (PK, int)  
- `Code` (unique)  
- `Amount`, `MinimumPurchase`, `UsageLimit`  
- `AppliesToAllServices` (bit)  
- `StartDate`, `EndDate`  
- `ServiceId` (FK → Service, optional)  
- `CreatedAt`, `UpdatedAt`  

**Relationships**
- 1 → * DiscountUsage  

**Delete Behavior**
- Cascade delete → DiscountUsage  

---

### DiscountUsage
**Fields**
- `Id` (PK, int)  
- `DiscountId` (FK → Discount)  
- `UserId` (FK → User, nullable if deleted)  
- `OrderId` (FK → Order, optional)  
- `UsedAt` (datetime)  

**Delete Behavior**
- Discount deletion → cascade delete usages  
- User deletion → UserId set to NULL, backend shows “Deleted User”  

---

### Payment
**Fields**
- `Id` (PK, int)  
- `Amount`  
- `PaymentMethod` (enum)  
- `TransactionId`  
- `PaymentDate`  
- `Status` (enum)  
- `OrderId` (FK → Order)  
- `UserId` (FK → User)  

**Delete Behavior**
- Payments are **never deleted** (financial data)  
- Orders may be deleted manually → Payment remains  

---

### Notification
**Fields**
- `Id` (PK, int)  
- `Title`, `Message`  
- `IsRead` (bit)  
- `UserId` (FK → User)  
- `CreatedAt`  

**Delete Behavior**
- Cascade delete with User  

---

### Address
**Fields**
- `Id` (PK, int)  
- `Government`, `City`, `PostalCode`, `Country`  
- `DeliveryNotes`  
- `UserId` (FK → User)  
- `CreatedAt`, `UpdatedAt`  

**Delete Behavior**
- Cascade delete with User  

---

### Review
**Fields**
- `Id` (PK, int)  
- `Comment`, `Rating`  
- `ServiceId` (FK → Service)  
- `UserId` (FK → User)  
- `CreatedAt`, `UpdatedAt`  

**Delete Behavior**
- Cascade delete if User deleted  
- Cascade delete if Service deleted  

---

## 4. Business Rules Reflected in DB
- **Unique Constraints**
  - `User.Email` must be unique  
  - `Discount.Code` must be unique  
- **Order Calculations**
  - `TotalAmount = SubTotal – DiscountAmount + DeliveryFee`  
- **Snapshots**
  - `OrderService.PriceAtOrder` and `ServiceTitleAtOrder` preserve history  
- **Enums**
  - Stored as strings  
- **Financial Integrity**
  - Orders & Payments are **always retained**  

---

## 5. Index Recommendations
- `User.Email` → Unique index  
- `Discount.Code` → Unique index  
- Foreign keys → auto-indexed by EF  
- Future: `Service.Title`, `Service.Category` for search  

---

## 6. Audit & Timestamps
- Standard: `CreatedAt`, `UpdatedAt`  
- Logs:
  - `DiscountUsage.UsedAt`  
  - `Payment.PaymentDate`  
  - `Notification.CreatedAt`  

---

## 7. Open Questions / Future Work
- Multi-currency support in Payment?  
- Soft delete instead of cascade for certain entities?  
- Analytics indexes for performance (Orders by Status, Revenue by Provider)?  
