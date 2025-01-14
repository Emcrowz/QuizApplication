export const ValidateCorrectAnswers = (
  providededAnswers: string[],
  correctAnswers: string[]
): boolean => {
  const numberOfCorrectAnswers = correctAnswers.length;
  let numberOfCorrectAnswersProvided = 0;

  providededAnswers.forEach((answer: string) => {
    if (correctAnswers.includes(answer)) {
      numberOfCorrectAnswersProvided++;
    }
  });

  return numberOfCorrectAnswers === numberOfCorrectAnswersProvided;
};
