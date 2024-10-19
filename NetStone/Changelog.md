## 1.3.0
### Breaking Changes
- AttackMagicPotency in Character Attributes is now nullable
- HealingMagicPotency in Character Attributes is now nullable
### New Features
- Character Attributes
  - Added Craftsmanship
  - Added Control
  - Added Gathering
  - Added Perception
- Free Company Member
  - Added Free Company Rank
  - Added Free Company Rank Icon
- Gear
  - Added item level
### Contributors
- Tawmy
- Corielljacob
## 1.2.1
### New Features
- Character
  - Added Bozja (credit to twobe7)
  - Added Eureka (credit to twobe7)
## 1.2.0
### Breaking Changes
- ClassJobs are now non-nullable. Use IsUnlocked instead of a null check
### Fixes
- Character achievements should now work as intended
- Added new jobs (credit to Tawmy)
### New Features
- Character
  - Added Tribe
  - Added Clan
  - Added Gender
## 1.1.2
### Fixes
- FreeCompany
  - Fix exception when no ranking is present
## 1.1.1
### Fixes
- Social Group 
  - Exists works as intended now
  - Id returns null when the group does not exist
## 1.1.0
### New Features
- Item HQ status
- Game data updated for 6.4
### Fixes
- Character
    - Level of active job
    - Materia
    - Job experience
    - Skill Speed
    - Achievement details
- Free Company
    - Active State
    - Leveling focus
### Technical changes
- Using C# built-in nullability (remove JetBrains annotations)
## 1.0.0
Initial Release