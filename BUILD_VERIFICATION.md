# 🔨 Build Verification Guide

**Purpose:** Pre-build checklist to catch errors BEFORE you compile  
**Time:** 5-10 minutes  
**Updated:** December 6, 2025  

---

## ✅ Pre-Build Checklist

Before you hit F5 or Build → Build Solution, verify:

### Step 1: File Locations (2 minutes)

- [ ] **StoreRepairService.vb** exists at:
  ```
  ViVeTool-GUI.Wpf/Services/StoreRepairService.vb
  ```
  Check: Right-click project → Add → New Item → should show this file

- [ ] **ExportService.vb** exists at:
  ```
  ViVeTool-GUI.Wpf/Services/ExportService.vb
  ```

- [ ] **ManualFeatureWindow.xaml** exists at:
  ```
  ViVeTool-GUI.Wpf/Views/ManualFeatureWindow.xaml
  ```

- [ ] **ManualFeatureWindow.xaml.vb** exists at:
  ```
  ViVeTool-GUI.Wpf/Views/ManualFeatureWindow.xaml.vb
  ```

**Result:** ✅ All 4 files in correct locations

---

### Step 2: Namespace Verification (2 minutes)

Open each file and verify the namespace declaration:

**StoreRepairService.vb:**
```vb
Namespace Services
    Public Class StoreRepairService
```
✅ Check: Namespace is `Services`

**ExportService.vb:**
```vb
Namespace Services
    Public Class ExportService
```
✅ Check: Namespace is `Services`

**ManualFeatureWindow.xaml:**
```xml
x:Class="ViVeTool_GUI.Wpf.ManualFeatureWindow"
```
✅ Check: Class path matches your project

**ManualFeatureWindow.xaml.vb:**
```vb
Namespace Views
    Public Partial Class ManualFeatureWindow
```
✅ Check: Namespace is `Views`

---

### Step 3: Import Requirements (3 minutes)

In **MainWindow.xaml.vb**, add these imports at the top:

```vb
Imports ViVeTool_GUI.Wpf.Views      ' For ManualFeatureWindow
Imports ViVeTool_GUI.Wpf.Services   ' For services
Imports Microsoft.Win32              ' For SaveFileDialog
Imports System.Collections.ObjectModel ' For ObservableCollection
```

**Verification:**
- [ ] All 4 imports present
- [ ] No red squiggly lines
- [ ] Intellisense shows available types

---

### Step 4: Reference Dependencies (2 minutes)

The new services depend on existing Albacore.ViVe library. Verify it's referenced:

**In Visual Studio:**
1. Right-click Solution → Properties
2. Expand "ViVeTool-GUI.Wpf"
3. Expand "Dependencies" → "Assemblies"
4. Look for: **Albacore.ViVe**

✅ Should be present (used by existing code)

---

## 🔨 Build Steps

### Option 1: Clean Build (Recommended First Time)

```
Build → Clean Solution
Build → Rebuild Solution
```

**Expected Output:**
```
========== Rebuild All: 5 succeeded, 0 failed, 0 skipped ==========
```

**If you see:**
```
========== Rebuild All: 4 succeeded, 1 failed, 0 skipped ==========
```
→ See troubleshooting section below

### Option 2: Normal Build

```
Build → Build Solution
or press Ctrl+Shift+B
```

**Expected Output:**
```
========== Build: 5 succeeded, 0 failed ==========
```

---

## 🐛 Common Build Errors & Fixes

### Error 1: "Type 'ManualFeatureWindow' is not defined"

**Cause:** Missing import

**Fix:**
```vb
' Add this to MainWindow.xaml.vb imports:
Imports ViVeTool_GUI.Wpf.Views
```

**Verify:** After adding import, error disappears

---

### Error 2: "'SaveFileDialog' is not declared"

**Cause:** Missing Microsoft.Win32 import

**Fix:**
```vb
' Add this to MainWindow.xaml.vb imports:
Imports Microsoft.Win32
```

**Verify:** Intellisense shows SaveFileDialog

---

### Error 3: "Name 'ObservableCollection' is not declared"

**Cause:** Missing System.Collections.ObjectModel import

**Fix:**
```vb
' Add this to MainWindow.xaml.vb imports:
Imports System.Collections.ObjectModel
```

**Verify:** Compiles without error

---

### Error 4: "The namespace 'Services' already contains a definition"

**Cause:** Duplicate file or duplicate class name

**Fix:**
1. Search project for duplicate StoreRepairService.vb files
2. Delete any duplicates (keep only in Services folder)
3. Rebuild

**Verify:** Only one StoreRepairService.vb file exists

---

### Error 5: "'YourFeatureCollection' is not declared"

**Cause:** Export handlers reference wrong collection name

**Fix:** In ExportFeaturesInternal handler, replace:
```vb
' WRONG:
result = Await _exportService.ExportToCSVAsync(YourFeatureCollection, dialog.FileName)

' CORRECT (use your actual collection name):
result = Await _exportService.ExportToCSVAsync(Features, dialog.FileName)
```

**Verify:** Matches your actual feature collection property/field name

---

### Error 6: "The type 'FeatureItem' is not defined"

**Cause:** Export handlers reference undefined type

**Status:** This is OK - it means your feature list uses a different type name

**Fix:** Check your existing code for the correct type:
```vb
' Find your feature class name (might be Feature, FeatureModel, etc.)
Dim features As ObservableCollection(Of ???)  ' What goes here?
```

Then update ExportService imports to match.

---

## ✅ Success Criteria

Your build is **READY TO RUN** when:

- [ ] Build output shows: "X succeeded, 0 failed"
- [ ] No error list items in Error window
- [ ] No red squiggly underlines in code
- [ ] Intellisense shows types correctly
- [ ] Project loads without warnings
- [ ] Can press F5 to start debugging

---

## 🧪 Quick Compile Test

Before running, do a quick verification:

```vb
' In MainWindow.xaml.vb, add temporary test code:
Private Sub TestCompile()
    ' This should compile without errors
    Dim repair As New StoreRepairService()
    Dim export As New ExportService()
    Dim manual As New ManualFeatureWindow()
End Sub
```

If this compiles, all types are correctly referenced.

**After verifying, delete the TestCompile method.**

---

## 📊 Expected Build Output

### Successful Build:
```
------ Build started: Project: ViVeTool-GUI.Wpf, Configuration: Debug Any CPU ------
ViVeTool-GUI.Wpf -> C:\Projects\ViVeTool-GUI\bin\Debug\ViVeTool-GUI.exe
========== Build: 5 succeeded, 0 failed, 0 skipped ==========
```

### Failed Build:
```
------ Build started: Project: ViVeTool-GUI.Wpf, Configuration: Debug Any CPU ------
StoreRepairService.vb(15,1): error BC30002: Type 'StoreRepairService' is not defined.
========== Build: 0 succeeded, 1 failed, 0 skipped ==========
```
→ See Troubleshooting section above

---

## 🎯 Next Steps After Successful Build

1. ✅ Build succeeded
2. Press **F5** to run
3. Application launches
4. Test Store Repair: Menu → Advanced → Repair Store
5. Test Export: Menu → File → Export Features → CSV
6. Test Manual Entry: Press **F12**
7. If all work → Ready to deploy!

---

## 🆘 Still Having Issues?

### Try These Steps:

1. **Clean & Rebuild:**
   ```
   Build → Clean Solution
   Build → Rebuild Solution
   ```

2. **Close & Reopen Project:**
   ```
   File → Close Solution
   File → Open → Select .sln file
   ```

3. **Check Dependencies:**
   ```
   Right-click Solution → Manage NuGet Packages
   Ensure all packages are up to date
   ```

4. **Review Imports:**
   ```
   Make sure all 4 imports are in MainWindow.xaml.vb
   No typos in namespace names
   ```

5. **Check File Encoding:**
   ```
   Right-click each new .vb file → Open With → Visual Studio
   Make sure encoding is UTF-8
   ```

---

## 📞 Getting Help

**If build still fails:**

1. Copy the **exact error message** from Error window
2. Check [TROUBLESHOOTING.md](TROUBLESHOOTING.md) for solutions
3. Review file locations (Step 1 above)
4. Verify all imports are present (Step 3 above)

---

**Your build should succeed with ZERO errors. Let me know if you hit any issues! ✅**
