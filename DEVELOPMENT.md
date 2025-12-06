# Development Guide

Welcome! This guide covers everything you need to know to contribute to ViVeTool GUI development.

## Getting Started

### Prerequisites

#### For WPF Version (.NET 9)
```
- Windows 10 Build 18963 or newer
- Visual Studio 2022 or VS Code
- .NET 9 SDK: https://dotnet.microsoft.com/download/dotnet/9.0
- Git
```

#### For Legacy WinForms Version (.NET Framework 4.8)
```
- Windows 10 Build 18963 or newer
- Visual Studio 2019+ or VS Code
- .NET Framework 4.8+ and Windows SDK
- Git
```

### Setting Up Your Environment

**Step 1: Clone the Repository**
```bash
git clone https://github.com/mta1124-1629472/ViVeTool-GUI.git
cd ViVeTool-GUI
```

**Step 2: Install Dependencies**

*WPF Version:*
```bash
# Install .NET 9 SDK
https://dotnet.microsoft.com/download/dotnet/9.0

# Restore NuGet packages
dotnet restore
```

*Legacy Version:*
- Open solution in Visual Studio
- NuGet packages restore automatically

**Step 3: Build the Project**

*WPF Version:*
```bash
# Debug build
dotnet build -c Debug

# Release build
dotnet build -c Release
```

*Legacy Version:*
```bash
# In Visual Studio
Build > Build Solution
```

**Step 4: Run the Application**

*WPF Version:*
```bash
dotnet run --project ViVeTool-GUI.Wpf
```

*Legacy Version:*
```bash
# In Visual Studio
Debug > Start Debugging
# Or run .exe from bin/Debug or bin/Release
```

## Project Structure

```
ViVeTool-GUI/
├── ViVeTool-GUI.Wpf/              # Modern WPF application
│   ├── Views/                     # XAML UI views
│   ├── ViewModels/                # MVVM ViewModels
│   ├── Models/                    # Data models
│   ├── Services/                  # Business logic
│   ├── Themes/                    # WPF themes and resources
│   ├── Converters/                # Value converters
│   └── Resources/                 # Localization/assets
│
├── ViVeTool-GUI.FeatureScanner/   # Feature scanning tool
│   ├── Scanner/                   # Core scanning logic
│   ├── Models/                    # Feature data structures
│   └── Services/                  # Scanning utilities
│
├── Albacore.ViVe/                 # ViVe API wrapper
│   ├── Api/                       # ViVe API interfaces
│   ├── Models/                    # ViVe data models
│   └── Interop/                   # Windows interop
│
├── vivetool-gui/                  # Legacy WinForms version
│   ├── Forms/                     # WinForms UI
│   ├── Models/                    # Data models
│   └── Services/                  # Business logic
│
├── lib/                           # External dependencies
├── images/                        # Assets and icons
├── ViVeTool_GUI.sln              # Visual Studio solution
└── building.md                   # Build instructions
```

## Architecture

### WPF Version (Recommended for New Development)

**Pattern:** MVVM (Model-View-ViewModel)

**Key Components:**
- **Views:** XAML files defining UI
- **ViewModels:** Logic and data binding
- **Models:** Data structures
- **Services:** ViVe API integration, feature feed, caching
- **Themes:** Windows 11 Fluent Design resources

**Data Flow:**
```
User Input → View → ViewModel → Service → Albacore.ViVe → Windows API
  ↓
UI Update ← Binding ← ViewModel Property Change ← Service
```

### Core Services

**FeatureFeedService**
- Downloads feature lists from GitHub
- Manages caching (ETag-based)
- Handles offline fallback

**ViVeService**
- Wraps Albacore.ViVe API
- Enables/disables features
- Queries feature states

**FeatureScannerService**
- Discovers hidden features
- Generates feature lists
- GitHub Actions integration

## Code Style & Standards

### Naming Conventions

```csharp
// Classes and Methods: PascalCase
public class FeatureViewModel { }
public void EnableFeature() { }

// Properties: PascalCase
public string FeatureName { get; set; }

// Private fields: _camelCase
private string _featureName;

// Constants: UPPER_CASE
private const string CACHE_FOLDER = "cache";

// Local variables: camelCase
var featureList = GetFeatures();
```

### Code Organization

- One class per file (except exceptions)
- Group related methods together
- Private methods after public methods
- Properties before methods
- Constants at top of class

### Documentation

```csharp
/// <summary>
/// Enables a Windows feature by its ID.
/// </summary>
/// <param name="featureId">The feature ID to enable</param>
/// <returns>True if successful, false otherwise</returns>
public bool EnableFeature(string featureId)
{
    // Implementation
}
```

## Working with ViVe API

### Albacore.ViVe Wrapper

The `Albacore.ViVe` project wraps the ViVe API for easier use:

```csharp
using Albacore.ViVe;

// Enable a feature
var success = ViVeApi.EnableFeature(featureId);

// Query feature state
var state = ViVeApi.GetFeatureState(featureId);

// Get all features
var features = ViVeApi.GetFeatures();
```

### ViVe API Documentation

See: https://github.com/thebookisclosed/ViVe

## Feature Development

### Adding a New Feature

**1. Design Phase**
- Create GitHub issue describing feature
- Discuss approach with maintainers
- Get approval before coding

**2. Implementation**
- Create feature branch: `feature/my-feature`
- Implement feature
- Add unit tests
- Update documentation

**3. Testing**
```bash
# Build and test
dotnet build
dotnet test  # If tests exist

# Manual testing on various Windows builds
# Test both success and error cases
```

**4. Documentation**
- Update README.md if user-facing
- Add code comments
- Update relevant .md files (FAQ.md, TROUBLESHOOTING.md, etc.)

**5. Pull Request**
- Push to your fork
- Create PR against `master` branch
- Provide detailed description
- Link related issues
- Await review

### Example: Adding Feature Export

**1. Service**
```csharp
public class FeatureExportService
{
    public void ExportToCSV(List<Feature> features, string filePath)
    {
        // Implementation
    }
}
```

**2. ViewModel**
```csharp
public ICommand ExportCommand { get; }

private void ExecuteExport()
{
    // Get features
    // Call service
    // Show success message
}
```

**3. View (XAML)**
```xml
<Button Content="Export" Command="{Binding ExportCommand}" />
```

**4. Tests**
```csharp
[TestMethod]
public void ExportToCSV_ValidFeatures_CreatesFile()
{
    // Arrange
    var features = GetTestFeatures();
    var service = new FeatureExportService();
    
    // Act
    service.ExportToCSV(features, "test.csv");
    
    // Assert
    Assert.IsTrue(File.Exists("test.csv"));
}
```

## Testing

### Unit Testing

Currently minimal test coverage. We welcome contributions!

**Test Structure:**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class FeatureServiceTests
{
    [TestMethod]
    public void EnableFeature_ValidId_ReturnsTrue()
    {
        // Arrange
        var service = new FeatureService();
        var featureId = "test-feature";
        
        // Act
        var result = service.EnableFeature(featureId);
        
        // Assert
        Assert.IsTrue(result);
    }
}
```

### Manual Testing Checklist

- [ ] App launches without errors
- [ ] Feature list loads
- [ ] Can enable features
- [ ] Can disable features
- [ ] Search works
- [ ] Theme switching works (WPF)
- [ ] Feature scanner works
- [ ] GitHub publishing works (maintainers)

## Debugging

### Visual Studio Debugging

**WPF Version:**
1. Open project in Visual Studio 2022
2. Press F5 to start debugging
3. Set breakpoints by clicking line numbers
4. Use Debug menu to step through code

**Legacy Version:**
1. Open solution in Visual Studio
2. Press F5 to start debugging
3. Debug window shows console output

### Logging

Add debug output:
```csharp
Debug.WriteLine($"Feature enabled: {featureId}");
System.Diagnostics.Trace.WriteLine("Message");
```

### Common Issues

**ViVe API Unavailable:**
- Running on non-Insider build
- Not running as Administrator
- Corrupted Windows feature store

**Feature List Won't Download:**
- No internet connection
- GitHub inaccessible
- Cache folder permissions issue

## Building for Release

### Creating Release Build

**WPF Version:**
```bash
dotnet publish -c Release -f net9.0-windows
```

Outputs to: `ViVeTool-GUI.Wpf/bin/Release/net9.0-windows/publish/`

**Legacy Version:**
```bash
# In Visual Studio
Build > Configuration Manager
# Select Release
Build > Build Solution
```

Outputs to: `vivetool-gui/bin/Release/`

### Creating Release Package

1. Build release version
2. Test thoroughly
3. Version bump (CHANGELOG.md)
4. Create GitHub release
5. Attach binaries
6. Write release notes

## Contributing Guidelines

### Before You Start

1. **Check existing issues:** Someone might be working on it
2. **Fork the repository:** Work on your own fork
3. **Create feature branch:** `feature/my-feature` or `fix/my-bug`
4. **Test thoroughly:** Both success and error cases
5. **Update documentation:** README, FAQ, etc. if user-facing

### Pull Request Process

1. **Descriptive title:** Clear what the PR does
2. **Detailed description:** Why this change is needed
3. **Link issues:** Reference #123 if related
4. **Screenshot/video:** If UI changes
5. **Testing:** Describe what you tested
6. **Breaking changes:** Document if any

### Commit Messages

```
Fix: Correct theme not applying on Windows 10
Add: Feature export to CSV functionality  
Refactor: Simplify FeatureService.cs
Docs: Update FAQ with Windows 10 tips
```

Keep messages clear and concise.

## Resources

### ViVeTool Documentation
- GitHub: https://github.com/thebookisclosed/ViVe
- Windows Feature documentation
- ViVe API reference

### .NET Resources
- [.NET Documentation](https://docs.microsoft.com/en-us/dotnet/)
- [WPF MVVM](https://docs.microsoft.com/en-us/archive/msdn-magazine/2009/february/patterns-wpf-apps-with-the-model-view-viewmodel-design-pattern)
- [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)

### Community
- **Discord:** [Join our community](https://discord.gg/8vDFXEucp2)
- **Issues:** [GitHub Issues](https://github.com/mta1124-1629472/ViVeTool-GUI/issues)
- **Discussions:** [GitHub Discussions](https://github.com/mta1124-1629472/ViVeTool-GUI/discussions)

## Roadmap

### WPF Version (Active Development)
- [ ] Multi-language localization
- [ ] Store repair functionality
- [ ] Feature export (CSV/JSON)
- [ ] Advanced search operators
- [ ] User settings persistence
- [ ] Integration tests
- [ ] Performance optimizations

### Legacy Version
- Maintenance only
- Critical bug fixes
- No new features

## Need Help?

- **Questions:** [GitHub Discussions](https://github.com/mta1124-1629472/ViVeTool-GUI/discussions)
- **Issues:** [GitHub Issues](https://github.com/mta1124-1629472/ViVeTool-GUI/issues)
- **Real-time Chat:** [Discord Server](https://discord.gg/8vDFXEucp2)

## License

By contributing, you agree that your contributions will be licensed under the same license as the project.

---

**Thank you for contributing to ViVeTool GUI!** 🙋
