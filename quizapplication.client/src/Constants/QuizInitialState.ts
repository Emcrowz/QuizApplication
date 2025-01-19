import { Participant } from "../Models/Participant";
import { Question } from "../Models/Question";
import { QuizStatus } from "./QuizStatus";

const defaultParticipant: Participant = {
  name: "" as string,
  email: "" as string,
  participationDate: new Date(),
  finalAnswers: [] as string[],
  score: 0,
};

export const quizInitialState = {
  status: QuizStatus.Loading as QuizStatus,
  participant: defaultParticipant as Participant,
  questions: [] as Question[],
  answers: [] as string[],
  index: 0,
};
