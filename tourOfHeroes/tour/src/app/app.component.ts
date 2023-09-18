import { Component } from '@angular/core';
import { UserService } from './service/user-service/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Dota 2 Compendium';

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ){}
  
  isUserAuthenticated = (): boolean => {
    return this.userService.isUserAuthenticated();
  }
  
  isMainPage(): boolean{
    // Get the current route path segments
    const pathSegments = this.route.snapshot.url.map(segment => segment.path);

    // Check if the path meets the condition to show the video
    // For example, you can check if the path is '/landing'
    return pathSegments.includes('landing');
  }
  
  logOut = () => {
    localStorage.removeItem("jwt");
  }
}
