export class Review
{
  name : string
  email : string
  message : string
  phoneNumber: string

  constructor(
    reviewName: string,
    reviewEmail: string,
    reviewMessage: string,
    reviewPhoneNumber: string)
  {
    this.name = reviewName;
    this.email = reviewEmail;
    this.message = reviewMessage;
    this.phoneNumber = reviewPhoneNumber;
  }
}
