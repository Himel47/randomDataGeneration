using DataGenerator.Models;
using System;

namespace DataGenerator.Operations
{
    public class DataOperations
    {
        private readonly ERegion _region;
        private readonly Random _random;

        public DataOperations(ERegion region, int seed)
        {
            _region = region;
            _random = new Random(seed);
        }

        public List<UserData> GenerateUserData(int pageNumber, int errorsPerRecord, int pageSize)
        {
            var userDataList = new List<UserData>();

            for (int i = 0; i < pageSize; i++)
            {
                var userData = new UserData
                {
                    Index = (pageNumber - 1) * pageSize + i + 1,
                    RandomIdentifier = GenerateRandomIdentifier(),
                    Name = GenerateName(_region),
                    MiddleName = GenerateMiddleName(_region),
                    LastName = GenerateLastName(_region),
                    Address = GenerateAddress(_region),
                    Phone = GeneratePhone(_region)
                };

                if (errorsPerRecord > 0)
                {
                    ApplyErrors(userData, errorsPerRecord);
                }

                userDataList.Add(userData);
            }

            return userDataList;
        }

        private string GeneratePhone(ERegion region)
        {
            var phoneNumberPrefixLookup = GetPhoneNumberPrefixLookup(region);
            var phoneNumberSuffixLookup = GetPhoneNumberSuffixLookup(region);

            var phoneNumberPrefix = phoneNumberPrefixLookup[_random.Next(0, phoneNumberPrefixLookup.Length)];
            var phoneNumberSuffix = phoneNumberSuffixLookup[_random.Next(0, phoneNumberSuffixLookup.Length)];

            return $"{phoneNumberPrefix}{phoneNumberSuffix}";
        }

        private string[] GetPhoneNumberPrefixLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "+48", "+49" };
                case ERegion.USA:
                    return new[] { "+1" };
                case ERegion.Georgia:
                    return new[] { "+995" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string[] GetPhoneNumberSuffixLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "123456789", "987654321" };
                case ERegion.USA:
                    return new[] { "1234567890", "9876543210" };
                case ERegion.Georgia:
                    return new[] { "123456789", "987654321" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }


        private string GenerateRandomIdentifier()
        {
            var randomIdentifier = Guid.NewGuid().ToString("N").Substring(0, 10);
            return randomIdentifier;
        }

        private string GenerateName(ERegion region)
        {
            var firstNameLookup = GetFirstNameLookup(region);
            var lastNameLookup = GetLastNameLookup(region);

            var firstName = firstNameLookup[_random.Next(0, firstNameLookup.Length)];
            var lastName = lastNameLookup[_random.Next(0, lastNameLookup.Length)];

            return $"{firstName} {lastName}";
        }

        private string[] GetFirstNameLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "Jan", "Piotr", "Katarzyna", "Agnieszka", "Michał" };
                case ERegion.USA:
                    return new[] { "John", "Emily", "Michael", "Sarah", "William" };
                case ERegion.Georgia:
                    return new[] { "გიორგი", "ნინო", "დავით", "მარიამ", "ლევან" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string GenerateLastName(ERegion region)
        {
            var lastNameLookup = GetLastNameLookup(region);

            var lastName = lastNameLookup[_random.Next(0, lastNameLookup.Length)];

            return lastName;
        }

        private string[] GetLastNameLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "Kowalski", "Wiśniewski", "Dąbrowski", "Kaczmarek", "Jankowski" };
                case ERegion.USA:
                    return new[] { "Smith", "Johnson", "Williams", "Jones", "Brown" };
                case ERegion.Georgia:
                    return new[] { "გელაშვილი", "მამულაშვილი", "გოგოლაძე", "კვარაცხელია", "ბერიძე" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string GenerateMiddleName(ERegion region)
        {
            var middleNameLookup = GetMiddleNameLookup(region);

            var middleName = middleNameLookup[_random.Next(0, middleNameLookup.Length)];

            return middleName;
        }

        private string[] GetMiddleNameLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "Jan", "Maria", "Anna", "Piotr", "Katarzyna" };
                case ERegion.USA:
                    return new[] { "Lee", "Marie", "Joy", "Ray", "Lynn" };
                case ERegion.Georgia:
                    return new[] { "გიორგი", "ნინო", "დავით", "მარიამ", "ლევან" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string GenerateAddress(ERegion region)
        {
            var cityLookup = GetCityLookup(region);
            var streetLookup = GetStreetLookup(region);
            var buildingLookup = GetBuildingLookup(region);
            var apartmentLookup = GetApartmentLookup(region);

            var city = cityLookup[_random.Next(0, cityLookup.Length)];
            var street = streetLookup[_random.Next(0, streetLookup.Length)];
            var building = buildingLookup[_random.Next(0, buildingLookup.Length)];
            var apartment = apartmentLookup[_random.Next(0, apartmentLookup.Length)];

            return $"{city}, {street} {building}, apt. {apartment}";
        }

        private string[] GetCityLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "Warszawa", "Kraków", "Łódź", "Wrocław", "Poznań" };
                case ERegion.USA:
                    return new[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
                case ERegion.Georgia:
                    return new[] { "თბილისი", "ბათუმი", "ქუთაისი", "რუსთავი", "გორი" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string[] GetStreetLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "ul. Marszałkowska", "ul. Krakowska", "ul. Warszawska", "ul. Gdańska", "ul. Poznańska" };
                case ERegion.USA:
                    return new[] { "Main St", "Broadway", "5th Ave", "Elm St", "Oak St" };
                case ERegion.Georgia:
                    return new[] { "აღმაშენებლის ქუჩა", "რუსთაველის ქუჩა", "ჩავჩავაძის ქუჩა", "ვაჟა-ფშაველას ქუჩა", "ბარათაშვილის ქუჩა" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string[] GetBuildingLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "1", "2", "3", "4", "5" };
                case ERegion.USA:
                    return new[] { "101", "202", "303", "404", "505" };
                case ERegion.Georgia:
                    return new[] { "1", "2", "3", "4", "5" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }

        private string[] GetApartmentLookup(ERegion region)
        {
            switch (region)
            {
                case ERegion.Poland:
                    return new[] { "1", "2", "3", "4", "5" };
                case ERegion.USA:
                    return new[] { "101", "202", "303", "404", "505" };
                case ERegion.Georgia:
                    return new[] { "1", "2", "3", "4", "5" };
                default:
                    throw new ArgumentException("Unsupported region", nameof(region));
            }
        }






        private void ApplyErrors(UserData userData, int errorsPerRecord)
        {
            for (int i = 0; i < errorsPerRecord; i++)
            {
                var errorType = (EErrorType)_random.Next(0, 3);
                switch (errorType)
                {
                    case EErrorType.DeleteCharacter:
                        DeleteCharacter(userData);
                        break;
                    case EErrorType.AddRandomCharacter:
                        AddRandomCharacter(userData);
                        break;
                    case EErrorType.SwapNearCharacters:
                        SwapNearCharacters(userData);
                        break;
                }
            }
        }

        private void DeleteCharacter(UserData userData)
        {
            var fieldName = GetRandomFieldName();
            var fieldValue = userData.GetType().GetProperty(fieldName).GetValue(userData).ToString();

            if (!string.IsNullOrEmpty(fieldValue))
            {
                var charIndex = _random.Next(0, fieldValue.Length);
                var charArray = fieldValue.ToCharArray();
                charArray[charIndex] = '\0';

                userData.GetType().GetProperty(fieldName).SetValue(userData, new string(charArray).Trim());
            }
        }

        private string GetRandomFieldName()
        {
            var properties = typeof(UserData).GetProperties();
            var fieldName = properties[_random.Next(0, properties.Length)].Name;

            return fieldName;
        }

        private void AddRandomCharacter(UserData userData)
        {
            var fieldName = GetRandomFieldName();
            var fieldValue = userData.GetType().GetProperty(fieldName).GetValue(userData).ToString();

            if (!string.IsNullOrEmpty(fieldValue))
            {
                var charIndex = _random.Next(0, fieldValue.Length + 1);
                var randomChar = (char)_random.Next('a', 'z' + 1); // or use a different character range
                var charArray = fieldValue.ToCharArray();
                Array.Resize(ref charArray, charArray.Length + 1);
                charArray[charIndex] = randomChar;

                userData.GetType().GetProperty(fieldName).SetValue(userData, new string(charArray));
            }
        }

        private void SwapNearCharacters(UserData userData)
        {
            var fieldName = GetRandomFieldName();
            var fieldValue = userData.GetType().GetProperty(fieldName).GetValue(userData).ToString();

            if (!string.IsNullOrEmpty(fieldValue) && fieldValue.Length > 1)
            {
                var charIndex = _random.Next(0, fieldValue.Length - 1);
                var charArray = fieldValue.ToCharArray();
                var temp = charArray[charIndex];
                charArray[charIndex] = charArray[charIndex + 1];
                charArray[charIndex + 1] = temp;

                userData.GetType().GetProperty(fieldName).SetValue(userData, new string(charArray));
            }
        }
    }
}
