import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/user.service';
import { NotificationsService } from 'src/app/shared/notifications.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styles: [
  ]
})
export class RegistrationComponent implements OnInit {
  
  constructor(
    public service:UserService,
    private toast: NotificationsService
    ) { }

  ngOnInit(): void {
    this.service.formModel.reset();
  }

  onSubmit(){
    this.service.register().subscribe(
      // success function
      (res:any) => {
        // check is succeeded
        if(res.succeeded) {
          this.service.formModel.reset();
          this.toast.showSuccess('Created new user!', 'Success!');
        } else {
          //looping through errors array
          res.errors.forEach((element:any) => {
            switch(element.code) {
              case 'DuplicateUserName':
                this.toast.showError('Duplicate User Name!', 'Failed!');
                // user name is already taken
              break;
              
              case 'InvalidUserName':
                this.toast.showError('Invalid User Name!', 'Failed');
              break;

              default :
                // registration failed
                this.toast.showError('Something went wrong!', 'Failed!');
              break;
            }
          });
        }
      },

      // error function
      err => {
        console.log(err);
        this.toast.showError('Something went wrong!', 'Failed!');
      }
    );
  }


}
