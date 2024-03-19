# *Mega Cars*

* [✏️ *Overview*](#%EF%B8%8F-overview)
* [📘 *Description*](#-description)
* [🛠️ *About the run of the project*](#%EF%B8%8F-about-the-run-of-the-project)
* [🔑 *Users*](#-users)
* [🪓 *Warning*](#-warning)
* [🚗 *Screenshots*](#-screenshots)
* [🌟 *Design Diagram*](#-design-diagram)

---
# ✏️ Overview
* Mega Cars is a `ASP.NET 6.0` web project in a SoftUni course. I started development in July 2023.
* ©️ It was created for student purposes. All images are copyrighted by the car companies.
* ©️ All videos are "free to use" from web sites for content creators.
* All items for correct web functionality are seeded.
*  The purpose of the site is for each of its users to browse, rent a car and buy merchandise.
      * *`As a first project, the style is a bit bad, but good practices are reserved.`*

*Technology stack:*

![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![jQuery](https://img.shields.io/badge/jquery-%230769AD.svg?style=for-the-badge&logo=jquery&logoColor=white)
![JavaScript](https://img.shields.io/badge/javascript-%23323330.svg?style=for-the-badge&logo=javascript&logoColor=%23F7DF1E)
![HTML5](https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)
![Windows 11](https://img.shields.io/badge/Windows%2011-%230079d5.svg?style=for-the-badge&logo=Windows%2011&logoColor=white)

---
# 📘 Description
> [!NOTE]
> * Users of the site
>   * Any user without an account can view the entire product assortment.
>   * Any user with an account can buy merchandise, rent a car and become Dealer if they want.
>   * Any dealer can add a car, which car can be rented by any user with an account.
>     * One car CANNOT be rented by two users.
>
> * Header
>   * There are the navigation links (click on the burger icon).
>
> * Home
>   * Contains a 3 awesome videos, which are cycling with animated button.
>
> * Footer
>   * All rights reserved ©️ and some links.
>
> * Cars
>   * In the car catalog has search bar and every user can look quickly the car which they want to rent.
>     * There is a filter according to the vehicle specification.
>
> * Store
>   * If you have an account - you can buy a merchandise. You will then see a "1" on the shopping cart.
>   * Proceed to payment - fill your user credentials and if you have promo code - write it!

---
# 🛠️ About the run of the project
> [!IMPORTANT]
> * Change server name in `appsettings.Development.json`
>   * Server=`{server_name}`\\\SQLEXPRESS;
>
> * Open `Package Manager Console` and run
> 
>       update-database


---
# 🔑 Users
> [!TIP]
> The server has some seeded users and Promo Code like a:
> 
> |*Type*    |*Email*|*Password*|
> |  :---:   |:---:|:---:|
> |default   |`user@user.com`|`user1122`|
> |Dealer    |`dealer@dealer.com`|`dealer1122`|
> |Admin     |`admin@admin.com`|`admin1122`|
> |Promo Code|`summer20`|

---
# 🪓 Warning
> [!WARNING]
> If you want to be a Dealer - you should know that:
> * Go to `Wanna be partner?` in the menu.
> * Fill in your phone number in the field.
>
> ‼️ The link to the `Dealerships` goes to the 404 page ‼️

---
# 🚗 Screenshots
* Home page
![home](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/8e8db704-8701-4932-8bb7-d423c6fc1b1b)

* Menu
![menu](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/0fcaefa6-5586-4a0d-a823-7e99201856ad)

* Cars
![cars](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/f2d0049a-1869-4b86-a945-55ef2f8e4606)

* Store
![store](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/275efec9-a839-44b6-ad7e-04fe9b4904c7)

* Shopping Cart
![shoppingCart](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/e82df24a-e4b4-4077-8221-f546d95527c2)

* Payment
![payment](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/1ec02f1b-75bc-4bd3-a8c9-d0f90692f764)

# 🌟 Design Diagram
![diagram](https://github.com/VladimirShalamanov/MegaCars-ASP.NET-WebProject2023/assets/102071427/6ec16a8c-f348-4f49-9708-d406d9a1f3a8)
