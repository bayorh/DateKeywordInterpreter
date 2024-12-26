# **Date Keyword Interpreter**

**Date Keyword Interpreter** is a NuGet package for interpreting and expanding date-related keywords 
into actual date and time values. It supports basic keywords like "today," "yesterday," and "tomorrow," 
as well as advanced formats like relative dates (e.g., "in 3 days," "2 weeks ago") and 
date math expressions (e.g., "NOW+2h," "NOW-1d"). 


---

## **Features**

- **Basic Keywords**: Interpret `today`, `yesterday`, `tomorrow`, `next week`, `last week`, etc.
- **Relative Dates**: Handle phrases like `in 5 days`, `3 months ago`, `1 year ago`.
- **Date Math**: Evaluate expressions like `NOW-2d`, `NOW+4h`.
- **Custom Formatting**: Generate dates in specific formats using expressions like `Format(NOW, "yyyy-MM-dd")`.
- **Extensibility**: Designed with the Factory and Strategy patterns for easily adding new parsers.

---

## **Installation**

Install the package via NuGet Package Manager or the .NET CLI:

### **NuGet Package Manager**
1. Open your project in Visual Studio.
2. Right-click on the project and select **Manage NuGet Packages**.
3. Search for `DateKeywordInterpreter` and install it.

### **.NET CLI**
```bash
dotnet add package DateKeywordInterpreter --version 1.0.0
```

---

## **Usage**

### **Setup**
To use the `DateInterpreter`, import the required namespace:

```csharp
using DateKeywordInterpreter;
```

### **Example Usage**
#### **Basic Interpretation**
```csharp
var interpreter = new DateInterpreter();

Console.WriteLine(interpreter.Interpret("today"));      // Outputs: Current date
Console.WriteLine(interpreter.Interpret("yesterday"));  // Outputs: Yesterday's date
Console.WriteLine(interpreter.Interpret("in 3 days"));  // Outputs: Date 3 days from now
Console.WriteLine(interpreter.Interpret("NOW-2h"));     // Outputs: Current time minus 2 hours
```

#### **Custom Formatting**
```csharp
var interpreter = new DateInterpreter();
Console.WriteLine(interpreter.Interpret("Format(NOW, \"yyyy-MM-dd\")"));  // Outputs: Current date in yyyy-MM-dd format
```

---


### **Key Components**
- **DateKeywordInterpreter**: The main entry point for interpreting date keywords.
- **IDateParser**: Interface for creating custom parsers.
- **DateParserFactory**: Implements the Factory Pattern to dynamically select parsers.

---

## **Contributing**

Contributions are welcome! If you'd like to add features or report issues:
1. Fork the repository.
2. Create a feature branch (`git checkout -b feature-name`).
3. Commit your changes (`git commit -m 'Add feature'`).
4. Push to the branch (`git push origin feature-name`).
5. Open a pull request.

---

## **License**

This project is licensed under the MIT License. See the `LICENSE` file for details.

---

## **Contact**

If you encounter any issues or have suggestions, please feel free to contact me via:
- **Email**: [bayonletoyyib@gmail.com](mailto:bayonletoheeb@gmail.com)
- **GitHub**: [GitHub Repository](https://github.com/bayorh/DateKeywordInterpreter.git)

---

