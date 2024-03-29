using System;

namespace LegacyApp
{
    public class UserService
    {
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (IsFirstNameCorrect(firstName) || IsLastNameCorrect(lastName))
            {
                return false;
            }

            if (IsEmailCorrect(email))
            {
                return false;
            }

            int age = CalculateAgeUsingBirthdate(dateOfBirth);

            if (IsUnderage(age))
            {
                return false;
            }

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(clientId);

            var user = new User
            {
                client = client,
                dateOfBirth = dateOfBirth,
                emailAddress = email,
                firstName = firstName,
                lastName = lastName
            };

            UpdateCreditLimit(client, user);

            if (UserHasCreditLimitBelow500(user))
            {
                return false;
            }

            UserDataAccess.AddUser(user);
            return true;
        }

        private static bool UserHasCreditLimitBelow500(User user)
        {
            return user.hasCreditLimit && user.creditLimit < 500;
        }

        private static void UpdateCreditLimit(Client client, User user)
        {
            if (IsClientVeryImportant(client))
            {
                user.hasCreditLimit = false;
            }
            else if (IsClientImportant(client))
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.lastName, user.dateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.creditLimit = creditLimit;
                }
            }
            else
            {
                user.hasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.lastName, user.dateOfBirth);
                    user.creditLimit = creditLimit;
                }
            }
        }

        private static bool IsClientImportant(Client client)
        {
            return client.type == "ImportantClient";
        }

        private static bool IsClientVeryImportant(Client client)
        {
            return client.type == "VeryImportantClient";
        }

        private static bool IsUnderage(int age)
        {
            return age < 21;
        }

        private static int CalculateAgeUsingBirthdate(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            int age = now.Year - dateOfBirth.Year;
            if (now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)) age--;
            return age;
        }

        private static bool IsEmailCorrect(string email)
        {
            return !email.Contains("@") && !email.Contains(".");
        }

        private static bool IsLastNameCorrect(string lastName)
        {
            return string.IsNullOrEmpty(lastName);
        }

        private static bool IsFirstNameCorrect(string firstName)
        {
            return string.IsNullOrEmpty(firstName);
        }
    }
}
