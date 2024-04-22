defmodule LibraryFees do
  @spec datetime_from_string(String.t()) :: %NaiveDateTime{}
  def datetime_from_string(string), do: NaiveDateTime.from_iso8601!(string)

  @spec before_noon?(%NaiveDateTime{}) :: boolean()
  def before_noon?(datetime), do: datetime.hour < 12

  @spec return_date(%NaiveDateTime{}) :: %Date{}
  def return_date(checkout_datetime) do
    if before_noon?(checkout_datetime) do
      checkout_datetime |> NaiveDateTime.add(28, :day)
    else
      checkout_datetime |> NaiveDateTime.add(29, :day)
    end
    |> NaiveDateTime.to_date()
  end

  @spec days_late(%Date{}, %NaiveDateTime{}) :: non_neg_integer()
  def days_late(planned_return_date, actual_return_datetime) do
    NaiveDateTime.to_date(actual_return_datetime)
    |> Date.diff(planned_return_date)
    |> then(fn days ->
      if days > 0 do
        days
      else
        0
      end
    end)
  end

  @spec monday?(%NaiveDateTime{}) :: boolean()
  def monday?(datetime), do: Date.day_of_week(datetime) == 1

  @spec calculate_late_fee(String.t(), String.t(), pos_integer()) :: pos_integer()
  def calculate_late_fee(checkout, return, rate) do
    checkout_date = datetime_from_string(checkout)
    expected_return_date = return_date(checkout_date)
    actual_return_date = datetime_from_string(return)

    late_fee = rate * days_late(expected_return_date, actual_return_date)

    if monday?(actual_return_date) do
      # 50% off
      Integer.floor_div(late_fee, 2)
    else
      late_fee
    end
  end
end
