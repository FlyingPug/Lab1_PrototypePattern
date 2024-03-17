import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { Review } from './models/review';
import { ReviewService } from './services/review-service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MatButtonModule } from '@angular/material/button'
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatRippleModule } from '@angular/material/core';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  providers: [ReviewService, HttpClient]
})
export class AppComponent {
  reviewForm: Review = new Review('', '', '', '');

  constructor(private readonly reviewService: ReviewService) {
    this.reviewForm = new Review('', '', '', '');
  }


  sendReview() {
    console.log('Отправка отзыва:', this.reviewForm);
    let model = new Review(
      this.reviewForm.email,
      this.reviewForm.message,
      this.reviewForm.name,
      this.reviewForm.phoneNumber);
    this.reviewService.postReview(model);
  }
}
