# Troubleshooting Guide

This guide covers solutions for common issues with ViVeTool GUI. For comprehensive issue details, see [KNOWN_ISSUES.md](KNOWN_ISSUES.md).

## Application Launch Issues

### Application won't start

**Error:** App crashes or refuses to launch

**Step 1: Check Prerequisites**
```
WPF Version:      .NET 9 runtime required
Legacy Version:   .NET Framework 4.8 required
```
- Download .NET from [Microsoft](https://dotnet.microsoft.com/download)
- Restart after installation

**Step 2: Run as Administrator**
- Right-click ViVeTool-GUI.exe
- Select "Run as administrator"
- Some features require elevated privileges

**Step 3: Check Antivirus/Firewall**
- Temporarily disable antivirus
- Add app to antivirus whitelist
- Check Windows Firewall isn't blocking it

**Step 4: Verify Windows Build**
- Go to Settings → System → About
- Confirm build is 18963 or newer
- Non-Insider builds have limited support

**Step 5: Clear Cache & Retry**
```
WPF:    Delete: %LocalAppData%\ViVeTool-GUI
Legacy: Delete: %AppData%\ViVeTool
```
- Restart application

### "Dependencies missing" error

**WPF Version:**
1. Install .NET 9 runtime: https://dotnet.microsoft.com/download/dotnet/9.0
2. Restart computer
3. Try launching again

**Legacy Version:**
1. Install .NET Framework 4.8: https://dotnet.microsoft.com/download/dotnet-framework/net48
2. Restart computer
3. Try launching again

### Application crashes on startup

**Try in order:**
1. Disable antivirus temporarily
2. Run in Safe Mode with Networking
3. Clear cache folder (see above)
4. Update Windows
5. Reinstall .NET runtime
6. [Report the issue](https://github.com/mta1124-1629472/ViVeTool-GUI/issues)

## Feature List Issues

### Feature list shows as empty or "Loading..."

**Symptoms:** App launches but no features appear

**Solution 1: Check Internet Connection**
- Feature lists download from GitHub
- Ensure internet is working
- Check if GitHub is accessible in your region

**Solution 2: Wait for Download**
- First launch downloads feature list (~5-30 seconds)
- Don't close the app during download
- Check network activity indicator

**Solution 3: Verify Build Number**
- Feature lists only exist for known builds
- Check Settings → System → About for your build
- If too old, no features available

**Solution 4: Clear Cache & Retry**
```
WPF:    Delete: %LocalAppData%\ViVeTool-GUI
Legacy: Delete: %AppData%\ViVeTool
```
- Restart application
- Wait for feature list to download

**Solution 5: Check GitHub Status**
- Visit [GitHub Status](https://www.githubstatus.com/)
- If GitHub is down, wait for recovery

### Feature list loads but some features missing

**Causes:**
- Feature list incomplete for your build
- Community hasn't discovered all features yet
- Your build is very new

**Solution:**
1. Use Feature Scanner to discover missing features
2. Publish results to help the community
3. Features are added as they're discovered

## Permission & Access Issues

### "Access Denied" when enabling features

**Symptoms:** Error when clicking "Perform Action"

**Step 1: Run as Administrator**
- Right-click ViVeTool-GUI.exe
- Select "Run as administrator"
- Some features require elevated privileges

**Step 2: Check User Permissions**
1. Settings → Accounts → Your info
2. Verify account type is Administrator
3. If Standard user, switch to Administrator account

**Step 3: Disable Antivirus**
- Temporarily disable antivirus/Windows Defender
- They may block writes to feature store
- Add app to whitelist

**Step 4: Check UAC (User Account Control)**
1. Settings → System → About
2. Go to Notifications & actions
3. Adjust UAC level if needed

**Step 5: Try Safe Mode**
1. Restart in Safe Mode with Networking
2. Try enabling the feature
3. Safer mode avoids conflicts

**Step 6: Check Feature Availability**
- Some features are locked "Always Enabled/Disabled"
- These cannot be changed by users
- Check feature state in the list

### "Failed to write to feature store" error

**Causes:**
- Insufficient permissions
- Antivirus blocking
- Corrupted store

**Solutions:**
1. Run as Administrator
2. Disable antivirus temporarily
3. Use store repair (Legacy version only):
   - Find "Fix Store" option
   - Run repair
   - Restart Windows

## Feature Behavior Issues

### Features don't stay enabled/disabled

**Problem:** Feature reverts to previous state

**Cause 1: Feature is Locked**
- Features marked "Always Enabled" or "Always Disabled" can't change
- Check feature's state in the list
- These are Windows-protected features

**Cause 2: Need System Restart**
- Some features require restart to apply
- Restart Windows and check if it persists
- Wait 30 seconds after enabling before restarting

**Cause 3: Windows Update Reset It**
- Windows updates can reset features
- Check for pending updates: Settings → Update & Security
- Install updates and try again

**Cause 4: Insufficient Permissions**
- Feature may require higher privilege level
- Try in Safe Mode
- Verify Administrator account

**Cause 5: Feature Dependency**
- Some features depend on others
- Enable dependencies first
- Disable in reverse order

### Feature appears as both enabled and disabled

**Problem:** Feature shows conflicting state

**Solution:**
1. Close and reopen app
2. Refresh feature list
3. Try disabling then enabling again
4. Clear cache and restart

If persistent, [report the bug](https://github.com/mta1124-1629472/ViVeTool-GUI/issues).

## Feature Scanner Issues

### Feature Scanner won't start

**Step 1: Check Prerequisites**
- Run as Administrator
- 1GB+ free disk space
- Windows Insider build

**Step 2: Disable Antivirus**
- Scanner modifies system files
- Temporarily disable antivirus
- Add to whitelist

**Step 3: Try Safe Mode**
1. Restart in Safe Mode with Networking
2. Launch app
3. Run Feature Scanner
4. Safer mode avoids conflicts

### Feature Scanner hangs/freezes

**Solutions:**
1. Wait 5+ minutes (scanning takes time)
2. Close other apps (free RAM)
3. Ensure 1GB+ free disk space
4. Disable antivirus
5. Try on fresh Windows install

### Feature Scanner crashes

**Try:**
1. Run as Administrator
2. Disable antivirus
3. Restart Windows
4. Free up disk space (1GB+)
5. Close unnecessary apps

**If still crashes:**
- [Report with details](https://github.com/mta1124-1629472/ViVeTool-GUI/issues)
- Include Windows build number
- Include error message if any

## GitHub Integration Issues

### GitHub token authentication fails

**Error:** "403 Forbidden" or "Authentication failed"

**Step 1: Check Token Validity**
1. Go to GitHub Settings → Developer settings → Personal access tokens
2. Verify token hasn't expired
3. Check token has `repo` + `workflow` scopes
4. Regenerate if needed

**Step 2: Verify Permissions**
- Only maintainers can publish
- Check you're a repository collaborator
- Contact project maintainers if needed

**Step 3: Check Network**
- Ensure stable internet connection
- GitHub.com is accessible
- No firewall blocking

### Publishing feature list fails

**Step 1: Verify Prerequisites**
- Feature Scanner completed successfully
- Have valid GitHub token
- Are repository maintainer
- Internet is connected

**Step 2: Check Token Scopes**
```
Required: repo + workflow
Create at: github.com/settings/tokens
```

**Step 3: Verify Build Number**
- Correct Windows build entered
- Build number format: e.g., "26100"

**Step 4: Check Storage**
- Ensure feature file generated
- ~1MB per feature list
- Verify disk space available

## Theme & Display Issues (WPF Only)

### Theme doesn't apply correctly

**Light/Dark Mode Issues:**
1. Check Settings → Personalization → Colors
2. Verify Windows is set to Light or Dark mode
3. Set app theme to "System"
4. Restart the application

**If still wrong:**
- Close all instances of app
- Delete cache: `%LocalAppData%\ViVeTool-GUI`
- Reopen app

### Accent color not showing

**Solutions:**
1. Check Settings → Personalization → Colors
2. Choose a solid color (not gradient)
3. Ensure "Accent color" is set
4. Restart application

### UI looks distorted/broken

**Try:**
1. Restart the application
2. Set theme to "System"
3. Disable GPU acceleration (if available)
4. Update graphics drivers
5. Clear cache

## Performance Issues

### App launches slowly

**First Launch:** Normal, downloading feature list

**Subsequent Launches:** Should be fast

**If slow:**
1. Disable antivirus scanning for the app
2. Close unnecessary applications
3. Upgrade RAM (if consistently slow)
4. Check available disk space

### Feature list scrolling is laggy

**Causes:** Many features loaded, low resources

**Solutions:**
1. Use search to filter features
2. Close other applications
3. Upgrade RAM
4. Enable GPU acceleration
5. Restart Windows

### Feature Scanner is very slow

**Normal behavior:** Scanning takes 5-15 minutes

**If taking longer:**
1. Check system resources (Task Manager)
2. Close unnecessary applications
3. Ensure antivirus not scanning
4. Verify disk isn't full

## Version-Specific Issues

### Legacy Version (WinForms)

**Store Repair Not Working:**
1. Run as Administrator
2. Close antivirus
3. Try restart
4. Restart Windows after repair

**Language Not Changing:**
1. Select language in settings
2. Restart application
3. Check language pack installed

### WPF Version

**Need Store Repair?**
- Not yet in WPF (planned)
- Use Legacy version for now
- Or use CLI: `vivetool /fixStore`

**Need Localization?**
- Not yet in WPF (planned)
- Use Legacy version for now
- Contribute translations when available

## Getting More Help

### I've tried everything and it still doesn't work

**Next Steps:**

1. **Check Documentation**
   - [FAQ.md](FAQ.md) - Common questions
   - [KNOWN_ISSUES.md](KNOWN_ISSUES.md) - Comprehensive issues
   - [README.md](README.md) - Getting started

2. **Join Community**
   - [Discord Server](https://discord.gg/8vDFXEucp2) - Real-time help
   - [GitHub Discussions](https://github.com/mta1124-1629472/ViVeTool-GUI/discussions) - Ask questions

3. **Report Bug**
   - [GitHub Issues](https://github.com/mta1124-1629472/ViVeTool-GUI/issues)
   - Include: Windows build, version, error message, steps to reproduce

### Collecting Diagnostic Info

When reporting issues, provide:

```
Windows Build: [From Settings > System > About]
ViVeTool Version: [App version number]
App Version: [WPF or Legacy]
Error Message: [Exact error text]
Steps to Reproduce:
  1. ...
  2. ...
  3. ...
Attached Files:
  - Screenshot
  - Log file (if available)
```

---

**For more specific help, check [FAQ.md](FAQ.md) or [join our Discord](https://discord.gg/8vDFXEucp2)!**
