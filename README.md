# 💱 Currency Converter (C# Console App)

A simple, menu-driven console application that converts between major world currencies using USD as the base rate.  
Built as a programming exercise to demonstrate clean coding, modular design, and user input validation.

---

## 🚀 Features

- **Currency Conversion**  
  Convert an entered amount between any two supported currencies using live-style base rates.

- **List All Currencies**  
  Display a table of available currencies with their conversion rates (based on USD).

- **Input Validation**  
  Ensures numeric input for amounts and valid currency codes before processing.

- **Simple CLI Navigation**  
  Clear menu options for intuitive navigation:
  - `1` – Convert currency  
  - `2` – List all currencies  
  - `3` – Exit application

---

## 🌍 Supported Currencies

| Code | Name                | Rate / USD |
|------|---------------------|-------------|
| USD  | US Dollar           | 1.000000    |
| EUR  | Euro                | 0.854101    |
| GBP  | British Pound       | 0.745700    |
| INR  | Indian Rupee        | 88.685344   |
| AUD  | Australian Dollar   | 1.526500    |
| CAD  | Canadian Dollar     | 1.393802    |
| SGD  | Singapore Dollar    | 1.291593    |
| CHF  | Swiss Franc         | 0.797388    |
| MYR  | Malaysian Ringgit   | 4.221235    |
| JPY  | Japanese Yen        | 149.382469  |
| CNY  | Chinese Yuan        | 7.135415    |

*(Rates are static and used for demonstration purposes.)*

---

## 🧠 Design Overview

- **Language:** C# (.NET)  
- **Data Structure:** `Dictionary<string, (string name, decimal rate)>`  
- **Architecture:** Modular methods for menu display, conversion logic, and data loading  
- **Conversion Formula:**  
  ```text
  converted = (amount / rateFrom) * rateTo

