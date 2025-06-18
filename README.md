# 🚗 **CarSimulator**

A **modular, console-based car driving simulation** built with **C# and .NET 9.0**. This project simulates vehicle behavior, driver states (tiredness and hunger), and integrates unit testing and external API interaction to ensure robust simulation.

---

## 📌 **Description**

**CarSimulator** is a C#-based simulation program that enables users to **interactively drive a virtual car** while monitoring internal systems and driver conditions.

### Key Capabilities:
- Command-line interface for driving (move, turn, reverse, refuel, rest)
- Real-time monitoring of **driver fatigue and hunger**
- Integration with the **RandomUser API** to simulate dynamic drivers
- Unit testing support via **MSTest** and **NUnit**
- Separation of concerns via **layered architecture**

---

## 🧩 **Project Structure**

CarSimulator → Main application (Car.cs, Driver.cs, etc.)
Services → API logic (GetTheApi.cs, ApiResponse.cs)
CarSimulator.Tests → MSTest unit & integration tests
CarSimulator.NUnit → NUnit-based alternative tests

yaml
Kopiera
Redigera

---

## ✅ **Features**

- ✅ Simulated **driver states**: Tiredness & Hunger  
- ✅ Turn-based driving mechanics  
- ✅ **Dynamic drivers** via public API  
- ✅ Test coverage with **MSTest** and **NUnit**  
- ✅ Mocking support using **Moq**  
- ✅ Fully console-based user interaction  
- ✅ Parallel test execution  

---

## 🛠 **Technologies Used**

- **C# (.NET 9.0)**
- **MSTest / NUnit**
- **Moq (Mocking Framework)**
- **Console UI**
- **HttpClient + Newtonsoft.Json**

---

## 🔧 **Installation**

```bash
git clone https://github.com/Nasi-Malek/CarSimulator.git
Then:

Open the solution in Visual Studio 2022 (v17.14+)

Restore NuGet packages

Build the solution with Ctrl + Shift + B

🧪 Testing Instructions
✔️ Run Tests via Visual Studio:
Use Test Explorer

Or run from CLI:

bash
Kopiera
Redigera
dotnet test CarSimulator.Tests
dotnet test CarSimulator.NUnit
🔍 Test Coverage Includes:
✅ Core logic tests: Fuel, Direction, Driver Fatigue

✅ Edge case testing: Hunger thresholds

✅ Integration tests: API consumption and deserialization (ApiTest.cs)

🚀 Usage
Run the CarSimulator project

A random driver is fetched from the API

Use the console options:

markdown
Kopiera
Redigera
1. Move forward  
2. Turn left  
3. Turn right  
4. Reverse  
5. Refuel  
6. Rest  
7. Exit
After every action, car and driver status will be displayed.

Created by Nasi-Malek – feel free to fork, contribute, or explore 🚘