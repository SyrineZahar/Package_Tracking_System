from django.http import HttpResponse
from django.core.mail import send_mail

def simple_mail(request):
    mail= request.GET.get('email')

    if not mail:
        return HttpResponse('No email provided!', status=400)
    
    send_mail(subject='Your package is ready',
              message='We wanna tell you that your package is ready and the delivery guy is going to call you',
              from_email='hello@demomailtrap.com',
              recipient_list=[mail])

    return HttpResponse('Email sent!')