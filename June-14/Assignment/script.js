const professionList = [
  "Doctor",
  "Teacher",
  "Software Developer",
  "Data Scientist",
  "Architect",
  "Artist",
  "Musician",
  "Photographer",
  "Writer",
  "Chef",
  "Athlete",
  "Scientist",
  "Researcher",
  "Entrepreneur",
  "Designer",
  "Consultant",
  "Psychologist",
  "Therapist",
  "Nurse",
];

function updateProfessionList(professions) {
  const datalist = document.getElementById("professionList");
  datalist.innerHTML = professions
    .map((prof) => `<option value="${prof}"></option>`)
    .join("");
}

updateProfessionList(professionList);

function calculateAge() {
  const dob = document.getElementById("dob").value;
  const dobError = document.getElementById("dobError");
  if (dob) {
    const birthDate = new Date(dob);
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const isBeforeBirthday =
      today.getMonth() < birthDate.getMonth() ||
      (today.getMonth() === birthDate.getMonth() &&
        today.getDate() < birthDate.getDate());
    if (isBeforeBirthday) {
      age--;
    }
    document.getElementById("age").value = age;
    dobError.textContent = "";
  } else {
    dobError.textContent = "Date of birth is required.";
  }
}

function validateField(fieldId, errorId, validationFn, errorMsg) {
  const field = document.getElementById(fieldId);
  const errorElement = document.getElementById(errorId);
  if (validationFn(field.value)) {
    errorElement.textContent = "";
    field.classList.remove("invalid-input");
    field.classList.add("valid-input");
  } else {
    errorElement.textContent = errorMsg;
    field.classList.remove("valid-input");
    field.classList.add("invalid-input");
  }
}

function validateName() {
  validateField(
    "name",
    "nameError",
    (value) => value.trim() !== "",
    "Name is required."
  );
}

function validatePhone() {
  validateField(
    "phone",
    "phoneError",
    (value) => /^[0-9]{10}$/.test(value),
    "Enter a valid 10-digit phone number."
  );
}

function validateDOB() {
  validateField(
    "dob",
    "dobError",
    (value) => value !== "",
    "Date of birth is required."
  );
}

function validateEmail() {
  validateField(
    "email",
    "emailError",
    (value) => /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/.test(value),
    "Enter a valid email address."
  );
}

function validateGender() {
  const genderError = document.getElementById("genderError");
  const genderChecked = document.querySelector('input[name="gender"]:checked');
  genderError.textContent = genderChecked ? "" : "Gender is required.";
}

function validateQualification() {
  const qualificationError = document.getElementById("qualificationError");
  const qualificationChecked = document.querySelector(
    'input[name="qualification"]:checked'
  );
  qualificationError.textContent = qualificationChecked
    ? ""
    : "At least one qualification is required.";
}

function validateProfession() {
  const profession = document.getElementById("profession").value;
  const professionError = document.getElementById("professionError");
  if (profession === "") {
    professionError.textContent = "Profession is required.";
  } else if (!professionList.includes(profession)) {
    professionList.push(profession);
    updateProfessionList(professionList);
    professionError.textContent = "";
  } else {
    professionError.textContent = "";
  }
}

function validateForm() {
  validateName();
  validatePhone();
  validateDOB();
  validateEmail();
  validateGender();
  validateQualification();
  validateProfession();

  const errors = document.querySelectorAll(".error");
  let formValid = true;
  errors.forEach((error) => {
    if (error.textContent !== "") {
      formValid = false;
    }
  });

  const formError = document.getElementById("formError");
  if (!formValid) {
    formError.textContent = "Please fix the errors above.";
  } else {
    formError.textContent = "";
    alert("Form submitted successfully!");
  }
}
