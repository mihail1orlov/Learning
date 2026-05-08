# Three points that define a fault plane

Given a known point on a geological fault, its dip angle, and its strike, three points are enough to define the plane it lies on. This note records the formulas.

## Inputs

1. **Fault point $(P)$** — a known point on the fault, in 3D coordinates $(x, y, z)$. This is the anchor.
2. **Dip angle $(\theta)$** — the angle between the horizontal plane and the fault plane, in degrees: `0°` is horizontal, `90°` is vertical.
3. **Strike $(\phi)$** — the bearing of the fault's surface trace, measured clockwise from north. The strike line is, by convention, perpendicular to the direction of steepest descent.

## Three points

- **Point 1 — $P$.** The given fault point.

- **Point 2 — along strike.** Step from $P$ along the strike direction. Strike lies in the horizontal plane, so the $z$ component is zero:

  $$\text{Point 2} = P + [\sin(\phi),\ \cos(\phi),\ 0]$$

- **Point 3 — along the dip direction.** Step from $P$ along the down-dip vector — the in-plane direction perpendicular to strike. Multiplying by $\sin(\theta)$ gives the horizontal component, $\cos(\theta)$ gives the vertical:

  $$\text{Point 3} = P + [\sin(\phi)\cdot\sin(\theta),\ -\cos(\phi)\cdot\sin(\theta),\ \cos(\theta)]$$

The three points are non-collinear and uniquely determine the fault plane.

## Caveats

In real-world geological data you'll usually want to:

- normalise the resulting basis vectors,
- pick the strike convention consistently (right-hand rule vs. left-hand rule),
- account for local coordinate-system handedness (especially when mixing seismic and well data).
