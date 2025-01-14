export const ValidateCorrectAnswers = (
  providededAnswers: string[],
  correctAnswers: string[]
): boolean => {
  const numberOfCorrectAnswers = correctAnswers.length;
  let numberOfCorrectAnswersProvided = 0;

  console.log(providededAnswers, correctAnswers);

  providededAnswers.forEach((answer: string) => {
    if (correctAnswers.includes(answer)) {
      numberOfCorrectAnswersProvided++;
    }
  });

  console.log(numberOfCorrectAnswers === numberOfCorrectAnswersProvided);

  return numberOfCorrectAnswers === numberOfCorrectAnswersProvided;
};
