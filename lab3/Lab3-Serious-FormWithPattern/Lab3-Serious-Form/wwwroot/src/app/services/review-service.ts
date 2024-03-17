import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../enviroment/enviroment.developer";
import { Review } from "../models/review";

@Injectable({
  providedIn: 'root'
})
export class ReviewService
{
  constructor(private readonly httpClient: HttpClient) {

  }

  public getReview(): Observable<Review[]> {
    return this.httpClient.get<Review[]>(environment.apiUrl + "reviews");
  }

  public postReview(review: Review) {
    console.log("sending", review);
    console.log(review);
    this.httpClient.post<Review>(environment.apiUrl + "reviews", review).subscribe({
      next: (data: any) => { console.log(data);},
      error: error => console.log(error)
    });
  }
}
