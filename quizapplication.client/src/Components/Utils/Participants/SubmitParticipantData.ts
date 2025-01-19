import { postParticipant } from "./ParticipantsApi";

interface SubmitResult {
  finalScore: number;
}

export const SubmitParticipantData = async (
  email: string,
  name: string,
  participationDate: Date,
  finalAnswers: string[],
  score: number
): Promise<SubmitResult | undefined> => {
  try {
    const data = await postParticipant({
      email,
      name,
      participationDate,
      finalAnswers,
      score,
    });

    return { finalScore: data };
  } catch (error) {
    console.error("Error submitting participant:", error);
  }
};
