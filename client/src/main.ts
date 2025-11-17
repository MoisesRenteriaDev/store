import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/app.config';
import { AppCompoment } from './app/app.component';

bootstrapApplication(AppCompoment, appConfig)
  .catch((err) => console.error(err));
