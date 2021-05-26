<?php
class FloatingPointPrecision
{
    private $SSize;
    private $ESize;
    private $MSize;
    private $Name;
    private $Standard;

    public function __construct($ssize, $esize, $msize, $name)
    {
        if ($ssize <= 0)
            throw new \http\Exception\InvalidArgumentException("Error: expected a positive size for sign (s) field but got $ssize.");
        elseif ($esize <= 0)
            throw new \http\Exception\InvalidArgumentException("Error: expected a positive size for exponent (e) field but got $esize.");
        elseif ($msize <= 0)
            throw new \http\Exception\InvalidArgumentException("Error: expected a positive size for mantissa (m) field but got $msize.");
        else {
            $this->SSize = $ssize;
            $this->ESize = $msize;
            $this->MSize = $msize;
            $this->Name = $name . CASE_UPPER . "_PRECISION";
        }
    }
}