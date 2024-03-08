-- PROCEDURE: public.sp_persons_upd(integer, text, text, date)

-- DROP PROCEDURE IF EXISTS public.sp_persons_upd(integer, text, text, date);

CREATE OR REPLACE PROCEDURE public.sp_persons_upd(
	IN person_id integer,
	IN first_name text,
	IN last_name text,
	IN dob date)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    UPDATE public."Persons"
    SET "FirstName" = first_name, "LastName" = last_name, "DoB" = dob
    WHERE "Id" = person_id;
END;
$BODY$;