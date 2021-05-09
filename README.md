## AlanMocek.LifeLog

Projects' responsibilities:

### AlanMocek.LifeLog.Core
- define domain models,
- implement domain oriented services
- take care of domain consistency

### AlanMocek.LifeLog.Application
- coordinate domain models and services work,
- share access to domain models through readonly records

### AlanMocek.LifeLog.Infrastructure
- define not domain oriented services
- define base types

### AlanMocek.LifeLog.Data
- define domain models configurations
- implement repositories
- define access to db


### AlanMocek.LifeLog.Client.Application
- define viewModels
- define converters

### AlanMocek.LifeLog.Client.Windows
- define views
- startup application with all services
