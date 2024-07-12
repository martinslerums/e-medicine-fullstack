import { zodResolver } from "@hookform/resolvers/zod";
import { SubmitHandler, useForm } from "react-hook-form";
import { z } from "zod";

const FormSchema = z.object({
  firstName: z.string(),
  lastName: z.string(),
  email: z.string().email(),
  password: z.string().min(8, {
    message: "Password must contain at least 8 characters",
  }),
});

type FormFields = z.infer<typeof FormSchema>;

const RegistrationForm = () => {
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors, isSubmitting },
  } = useForm<FormFields>({
    defaultValues: {
      firstName: "",
      lastName: "",
      email: "",
      password: "",
    },
    resolver: zodResolver(FormSchema),
  });

  const onSubmit: SubmitHandler<FormFields> = async (data: FormFields) => {
    try {
      const response = await fetch('http://localhost:5001/api/Users/register', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data),
      });

      if (!response.ok) {
        setError("root", {
          message: "Registration failed. Please try again later.",
        });
      }

      const responseData = await response.json();
      console.log(responseData);
    } catch (error) {
      setError("root", {
        message: "Registration failed. Please try again later.",
      });
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <input {...register("firstName")} type="text" placeholder="First name" />
      {errors.firstName && <div>{errors.firstName.message}</div>}

      <input {...register("lastName")} type="text" placeholder="Last name" />
      {errors.lastName && <div>{errors.lastName.message}</div>}

      <input {...register("email")} type="email" placeholder="E-mail" />
      {errors.email && <div>{errors.email.message}</div>}

      <input {...register("password")} type="password" placeholder="Password" />
      {errors.password && <div>{errors.password.message}</div>}

      <button disabled={isSubmitting} type="submit">
        {isSubmitting ? "Loading..." : "Submit"}
      </button>

      {errors.root && <div>{errors.root.message}</div>}
    </form>
  );
};

export default RegistrationForm;
