import { zodResolver } from "@hookform/resolvers/zod";
import { SubmitHandler, useForm } from "react-hook-form";
import { z } from "zod";

const FormSchema = z.object({
  email: z.string().email(),
  password: z.string().min(8, {
    message: "Password must contain at least 8 characters",
  }),
});

type FormFields = z.infer<typeof FormSchema>;

const LoginForm = () => {
  const {
    register,
    handleSubmit,
    setError,
    formState: { errors, isSubmitting },
  } = useForm<FormFields>({
    defaultValues: {
      email: "",
      password: "",
    },
    resolver: zodResolver(FormSchema),
  });

  const onSubmit: SubmitHandler<FormFields> = async (data: FormFields) => {
    try {
      const response = await fetch("http://localhost:5001/api/Users/login", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(data),
      });

      const responseData = await response.json();

      if (!response.ok) {
        setError("root", {
          message: responseData.message || "Login failed. Please try again later.",
        });
      } else {
        console.log(responseData);
      }
    } catch (error) {
      setError("root", {
        message: "An error occurred. Please try again later.",
      });
    }
  };

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
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

export default LoginForm;
