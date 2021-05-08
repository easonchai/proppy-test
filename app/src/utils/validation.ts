const regex = {
  EMAIL_REGEX: /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/,
  PHONE_NUMBER_REGEX: /^[+]?[0-9]{8,}?[\b]*$/,
  SALARY_REGEX: /^[0-9]+[\b]*$/,
};

export function validateEmail(email: string) {
  const emailRegex = regex.EMAIL_REGEX;
  if (emailRegex.test(email)) return true;
  return false;
}

export function validatePhone(phone: string) {
  const phoneRegex = regex.PHONE_NUMBER_REGEX;
  if (phoneRegex.test(phone)) return true;
  return false;
}

export function validateSalary(salary: string) {
  const salaryRegex = regex.SALARY_REGEX;
  if (salaryRegex.test(salary)) return true;
  return false;
}
