# Conda — install for geostatistics

Two libraries that show up everywhere in the geo notebooks: `scikit-learn` for general ML and data work, `pykrige` for kriging.

## Install

```bash
conda install scikit-learn
conda install -c conda-forge pykrige
```

`pykrige` lives on the `conda-forge` channel — without `-c conda-forge` Conda won't find it.

## Update Conda itself

```bash
conda update -n base -c defaults conda
```

If this fails ("PackagesNotFoundError" or the resolver hangs), it's usually fine to leave Conda at its current version and move on — most issues come from mixing channels in the same environment, not from the Conda binary being old.
